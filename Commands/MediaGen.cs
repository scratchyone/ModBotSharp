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
using ModBot.APIs;
using DSharpPlus.EventArgs;

namespace ModBot.Commands
{
    public class MediaGenCommands : Cog
    {
        public dataContext context { private get; set; }
        public IConfiguration Configuration { private get; set; }

        [Command("imagepoll")]
        [Description("Create a yes/no poll")]
        public async Task ImagePollCommand(CommandContext ctx, [Description("Title of the poll")][RemainingText] string text)
        {
            // TODO: Add flash warning
            var mediaGen = new MediaGen(Configuration["MediaGen"]);
            mediaGen.AssertOnline();
            var pollMessage = await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                .WithTitle(text)
                .WithAuthor(name: ctx.Member.DisplayName, iconUrl: ctx.Member.AvatarUrl)
                .WithImageUrl(mediaGen.GeneratePollURL(0, 0)));
            await pollMessage.CreateReactionAsync(DiscordEmoji.FromUnicode("👍"));
            await pollMessage.CreateReactionAsync(DiscordEmoji.FromUnicode("👎"));
            try { await ctx.Message.DeleteAsync(); } catch { }
            await context.Polls.AddAsync(new Poll { Message = pollMessage.Id.ToString() });
            await context.SaveChangesAsync();
        }

        [Command("pick"), Aliases("choose", "select")]
        [Description("Pick a random item")]
        public async Task AvatarCommand(CommandContext ctx, [Description("The items to pick (seperated by ;)"), RemainingText] string options)
        {
            var mediaGen = new MediaGen(Configuration["MediaGen"]);
            mediaGen.AssertOnline();
            var gif = await mediaGen.GetCoinFlip();
            var gifMessage = await ctx.RespondAsync(new DiscordEmbedBuilder().WithImageUrl(gif.imageURL));
            await Task.Delay(gif.length);
            await gifMessage.ModifyAsync(
                embed: Embeds.Info.WithTitle("")
                .WithDescription(options.Split(";").RandomElement())
                .Build());
        }
        [Command("owo")]
        [Description("Display a gif")]
        public async Task OwOCommand(CommandContext ctx,
            [Description("Action to get a gif of")] string action,
            [Description("Person you want to do the action to (optional)")] DiscordMember person)
        {
            var mediaGen = new MediaGen(Configuration["MediaGen"]);
            mediaGen.AssertOnline();
            if (action != "help")
            {
                var owoInfo = await mediaGen.GetOwoInfo(action, ctx.Member.DisplayName, person == null ? null : person.DisplayName);
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                    .WithAuthor(name: owoInfo.authorName, iconUrl: ctx.Member.AvatarUrl)
                    .WithImageUrl(owoInfo.imageURL)
                    .WithColor(new DiscordColor(owoInfo.color)));
            }
            else
            {
                await ctx.RespondAsync($"Possible actions are {string.Join(", ", await mediaGen.GetOwoActions())}");
            }
        }
        [Command("owo")]
        public async Task OwOCommand(CommandContext ctx, [Description("Action to get a gif of")] string action)
        {
            await OwOCommand(ctx, action, null);
        }
        new public static void OnStart(DiscordClient discord, IConfiguration Configuration)
        {
            discord.MessageReactionAdded += (a, b) => OnReactionChange(a, b.Message, Configuration);
            discord.MessageReactionRemoved += (a, b) => OnReactionChange(a, b.Message, Configuration);
        }
        public async static Task OnReactionChange(DiscordClient BaseDiscordClient, DiscordMessage reactionMsg, IConfiguration Configuration)
        {
            var context = new dataContext();
            try
            {
                var mediaGen = new MediaGen(Configuration["MediaGen"]);
                if (context.Polls.SingleOrDefault(p => p.Message == reactionMsg.Id.ToString()) != null)
                {
                    var msg = await reactionMsg.Channel.GetMessageAsync(reactionMsg.Id);
                    var up = msg.Reactions.FirstOrDefault(r => r.Emoji == DiscordEmoji.FromUnicode("👍"));
                    var down = msg.Reactions.FirstOrDefault(r => r.Emoji == DiscordEmoji.FromUnicode("👎"));
                    await msg.ModifyAsync(embed: new DiscordEmbedBuilder(msg.Embeds[0])
                                        .WithImageUrl(mediaGen.GeneratePollURL(up == null ? 0 : up.Count - 1, down == null ? 0 : down.Count - 1)).Build());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}