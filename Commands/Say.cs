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
        public async Task SayCommand(CommandContext ctx, DiscordChannel channel, [RemainingText] string text)
        {
            if (!(channel.PermissionsFor(ctx.Member).HasPermission(Permissions.ManageMessages) || ctx.Member.Id.ToString() == Configuration["Owner"]))
                throw new UserError("You don't have permission to do that");
            await channel.SendMessageAsync(text);
            try { await ctx.Message.DeleteAsync(); } catch { }
        }
    }
}