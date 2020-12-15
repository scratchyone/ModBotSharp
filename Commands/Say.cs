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

namespace ModBot.Commands
{
    [RequireGuild]
    public class Say : Cog
    {
        public IConfiguration Configuration { private get; set; }
        [Command("say")]
        [Description("Make the bot say something in a channel")]
        public async Task SayCommand(CommandContext ctx,
            [Description("Channel to send the message in")] DiscordChannel channel,
            [Description("Text to send")][RemainingText] string text)
        {
            if (channel.GuildId != ctx.Guild.Id) return;
            if (!(channel.PermissionsFor(ctx.Member).HasPermission(Permissions.ManageMessages) || ctx.Member.Id.ToString() == Configuration["Owner"]))
                throw new UserError("You don't have permission to do that");
            await channel.SendMessageAsync(text);
            try { await ctx.Message.DeleteAsync(); } catch { }
        }
        [Command("pin")]
        [RequireUserPermissions(Permissions.ManageMessages)]
        [Description("Make the bot say something in a channel and then pin it")]
        public async Task PinCommand(CommandContext ctx, [Description("Text to pin")][RemainingText] string text)
        {
            await (await ctx.Channel.SendMessageAsync(text)).PinAsync();
            try { await ctx.Message.DeleteAsync(); } catch { }
        }
    }
}