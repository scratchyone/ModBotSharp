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
using ModBot.Converters;
using Microsoft.EntityFrameworkCore;

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
                if (channel.GuildId != ctx.Guild.Id) return;
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
                if (channel.GuildId != ctx.Guild.Id) return;
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
        [Command("whosaid")]
        public async Task WhoSaid(CommandContext ctx, ulong id)
        {
            var messageSender = context.Anonmessages.SingleOrDefault(m => m.Id == id.ToString() && m.Server == ctx.Guild.Id.ToString());
            if (messageSender == null) throw new UserError("Message not found");
            await ctx.RespondAsync(embed: Embeds.Info.WithTitle($"Sender of Message {id}")
                .WithDescription($"<@{messageSender.User}>"));
        }

        [RequireUserPermissions(Permissions.ManageMessages)]
        [Command("anonban")]
        public async Task AnonBan(CommandContext ctx, DiscordUser user)
        {
            var oldBan = context.AnonBans.SingleOrDefault(b => b.User == user.Id.ToString() && b.Server == ctx.Guild.Id.ToString());
            if (oldBan != null) context.Remove(oldBan);
            await context.AnonBans.AddAsync(new AnonBan
            {
                User = user.Id.ToString(),
                Server = ctx.Guild.Id.ToString()
            });
            await context.SaveChangesAsync();
            await ctx.RespondAsync(embed: Embeds.Success.WithDescription($"Banned {user.Mention} permanently"));
        }
        [Command("anonban")]
        public async Task AnonBan(CommandContext ctx, DiscordUser user, TimeSpan time)
        {
            var oldBan = context.AnonBans.SingleOrDefault(b => b.User == user.Id.ToString() && b.Server == ctx.Guild.Id.ToString());
            if (oldBan != null) context.Remove(oldBan);
            await context.SaveChangesAsync();
            await context.AnonBans.AddAsync(new AnonBan
            {
                User = user.Id.ToString(),
                Server = ctx.Guild.Id.ToString(),
                ExpiresAt = (ulong)(DateTimeOffset.Now.ToUnixTimeSeconds() + time.TotalSeconds)
            });
            await context.SaveChangesAsync();
            await ctx.RespondAsync(embed: Embeds.Success.WithDescription($"Banned {user.Mention} temporarily"));
        }
        [RequireUserPermissions(Permissions.ManageMessages)]
        [Command("anonunban")]
        public async Task AnonUnBan(CommandContext ctx, DiscordUser user)
        {
            var oldBan = context.AnonBans.SingleOrDefault(b => b.User == user.Id.ToString() && b.Server == ctx.Guild.Id.ToString());
            if (oldBan != null) context.Remove(oldBan);
            else throw new UserError("User is not banned");
            await context.SaveChangesAsync();
            await ctx.RespondAsync(embed: Embeds.Success.WithDescription($"Unbanned {user.Mention}"));
        }
#pragma warning disable 4014
        public static void OnStart(DiscordClient discord, IConfiguration configuration)
        {
            var context = new dataContext();
            discord.MessageCreated += async (client, args) =>
            {
                Task.Run(async () =>
                    {
                        if (!args.Message.Content.StartsWith("\\") // Not escaped
                            && context.Anonchannels.Any(c => c.Id == args.Channel.Id.ToString()) // In an anon channel
                            && !args.Author.IsBot // Not a bot
                            && !context.AnonBans.AsNoTracking().AsEnumerable().Any(u => u.User == args.Author.Id.ToString()
                               && u.Server == args.Guild.Id.ToString()
                               && (u.ExpiresAt == (ulong)0 || u.ExpiresAt > (ulong)DateTimeOffset.Now.ToUnixTimeSeconds()))) // Not anonbanned
                        {
                            if (args.Message.Attachments.Count == 0) try { await args.Message.DeleteAsync(); } catch { }
                            // TODO: Work around rate limit here
                            var webhook = await args.Channel.CreateWebhookAsync("Anon");
                            var msg = new DiscordWebhookBuilder().WithContent(args.Message.Content);
                            foreach (var attachment in args.Message.Attachments)
                            {
                                var fileStream = WebRequest.Create(attachment.ProxyUrl).GetResponse().GetResponseStream();
                                msg.AddFile(attachment.FileName, fileStream);
                            }
                            var anonMessage = await webhook.ExecuteAsync(msg);
                            await webhook.DeleteAsync();
                            try { await args.Message.DeleteAsync(); } catch { }
                            await context.Anonmessages.AddAsync(new Anonmessage
                            {
                                Id = anonMessage.Id.ToString(),
                                Server = anonMessage.Channel.GuildId.ToString(),
                                User = args.Author.Id.ToString()
                            });
                            await context.SaveChangesAsync();
                        }


                    }
                );
            };
        }
    }
#pragma warning restore 4014

}