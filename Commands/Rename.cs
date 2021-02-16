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
    [RequireGuild]
    public class Rename : Cog
    {
        public dataContext context { private get; set; }

        [Command("setchannelname")]
        [Description("Set the name of the current channel")]
        [RequireUserPermissions(Permissions.ManageChannels)]
        public async Task SetChannelName(CommandContext ctx, [Description("New channel name")][RemainingText] string name)
        {
            await ctx.Channel.ModifyAsync(c => c.Name = name);
            await ctx.RespondAsync(embed: Embeds.Success.WithDescription("Set channel name!"));
        }

        [Command("setservername")]
        [Description("Set the name of the current server")]
        [RequireUserPermissions(Permissions.ManageGuild)]
        public async Task SetServerName(CommandContext ctx, [Description("New server name")][RemainingText] string name)
        {
            await ctx.Guild.ModifyAsync(c => c.Name = name);
            await ctx.RespondAsync(embed: Embeds.Success.WithDescription("Set server name!"));
        }
    }
}