using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Linq;
using ModBot.Models;
using System.Diagnostics;
using DSharpPlus.Net.Models;

namespace ModBot.Commands
{
    public class Rename : Cog
    {
        public dataContext context { private get; set; }

        [Command("setchannelname")]
        [RequireUserPermissions(Permissions.ManageChannels)]
        public async Task SetChannelName(CommandContext ctx, [RemainingText] string name)
        {
            await ctx.Channel.ModifyAsync(c => c.Name = name);
            await ctx.RespondAsync(embed: Embeds.Success.WithDescription("Set channel name!"));
        }

        [Command("setservername")]
        [RequireUserPermissions(Permissions.ManageGuild)]
        public async Task SetServerName(CommandContext ctx, [RemainingText] string name)
        {
            await ctx.Guild.ModifyAsync(c => c.Name = name);
            await ctx.RespondAsync(embed: Embeds.Success.WithDescription("Set server name!"));
        }
    }
}