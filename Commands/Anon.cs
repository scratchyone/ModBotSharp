using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Linq;
using ModBot.Models;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace ModBot.Commands
{
    [RequireGuild]
    public class Anon : Cog
    {
        public dataContext context { private get; set; }

        [RequireUserPermissions(Permissions.ManageChannels)]
        [Group("setanonchannel")]
        public class SetAnonChannel : BaseCommandModule
        {
            public dataContext context { private get; set; }

            [Command("enabled")]
            public async Task EnableAnonChannel(CommandContext ctx, DiscordChannel channel)
            {
                if (context.Anonchannels.Any(c => c.Id == channel.Id.ToString()))
                    throw new UserError("That channel is already enabled");
                await context.AddAsync(new Anonchannel { Id = channel.Id.ToString(), Server = channel.GuildId.ToString() });
                await context.SaveChangesAsync();
                await ctx.RespondAsync(embed: Embeds.Success.WithDescription($"Enabled {channel.Mention}! Start a message with \\ to prevent it from being sent anonymously"));
            }

            [Command("enabled")]
            public async Task EnableAnonChannel(CommandContext ctx)
            {
                await EnableAnonChannel(ctx, ctx.Channel);
            }

            [Command("disabled")]
            public async Task DisableAnonChannel(CommandContext ctx, DiscordChannel channel)
            {
                var ac = context.Anonchannels.SingleOrDefault(c => c.Id == channel.Id.ToString());
                if (ac == null)
                    throw new UserError("That channel is already disabled");
                context.Remove(ac);
                await context.SaveChangesAsync();
                await ctx.RespondAsync(embed: Embeds.Success.WithDescription($"Disabled {channel.Mention}!"));
            }
            [Command("disabled")]
            public async Task DisableAnonChannel(CommandContext ctx)
            {
                await DisableAnonChannel(ctx, ctx.Channel);
            }
        }
        [Command("listanonchannels")]
        public async Task ListAnonChannels(CommandContext ctx)
        {
            var anonChannels = string.Join("\n", context.Anonchannels.Where(c => c.Server == ctx.Guild.Id.ToString())
                .Select(channel => $"<#{channel.Id}>"));
            if (anonChannels.Length == 0) anonChannels = "*There are no anon channels enabled in this server*";
            await ctx.RespondAsync(embed: Embeds.Info.WithTitle("Anon Channels").WithDescription(anonChannels));
        }
        public static void OnStart(DiscordClient discord, IConfiguration configuration)
        {
            var context = new dataContext();
            discord.MessageCreated += async (client, args) =>
            {
#pragma warning disable 4014
                Task.Run(async () =>
                    {
                        if (!args.Message.Content.StartsWith("\\") // Not escaped
                            && context.Anonchannels.Any(c => c.Id == args.Channel.Id.ToString()) // In an anon channel
                            && !args.Author.IsBot) // Not a bot
                        {
                            if (args.Message.Attachments.Count == 0) try { await args.Message.DeleteAsync(); } catch { }
                            var webhook = await args.Channel.CreateWebhookAsync("Anon");
                            var msg = new DiscordWebhookBuilder().WithContent(args.Message.Content);
                            foreach (var attachment in args.Message.Attachments)
                            {
                                var fileStream = WebRequest.Create(attachment.ProxyUrl).GetResponse().GetResponseStream();
                                msg.AddFile(attachment.FileName, fileStream);
                            }
                            await webhook.ExecuteAsync(msg);
                            await webhook.DeleteAsync();
                            try { await args.Message.DeleteAsync(); } catch { }
                        }

                    }
                );
#pragma warning restore 4014
            };
        }
    }

}