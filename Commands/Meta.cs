using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Linq;
using ModBot.Models;
using System.Diagnostics;

namespace ModBot.Commands
{
    public class Meta : Cog
    {
        public dataContext context { private get; set; }

        [Command("support")]
        public async Task Support(CommandContext ctx)
        {
            await ctx.RespondAsync("https://discord.gg/wJ2TCpx");
        }
        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.RespondAsync($"Pong! Took {Math.Round((ctx.Message.CreationTimestamp - DateTime.Now).TotalMilliseconds)} ms");
        }
        [Command("invite")]
        public async Task Invite(CommandContext ctx)
        {
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                .WithTitle("Click here to invite ModBot to your server")
                .WithUrl(ctx.Client.CreateInvite())
                .WithDescription("Thank you for using ModBot! <:pOg:759186176094765057>")
                .WithColor(new DiscordColor("#9168a6"))
                .WithFooter("Made with ❤️"));
        }
        [Command("about")]
        public async Task About(CommandContext ctx)
        {
            var restartedMinutesAgo = Math.Round((DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()).TotalMinutes, 2);
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                .WithTitle("About ModBot")
                .WithDescription($"ModBot is in {ctx.Client.Guilds.Count} servers. ModBot was last restarted {restartedMinutesAgo} minutes ago")
                .WithColor(new DiscordColor("#9168a6"))
                .WithFooter("Made with ❤️"));
        }
    }
}