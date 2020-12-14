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
    [RequireGuild]
    public class Delete : Cog
    {
        public dataContext context { private get; set; }

        [Command("deletechannel")]
        [RequireUserPermissions(Permissions.ManageChannels)]
        public async Task DeleteChannel(CommandContext ctx)
        {
            // TODO: Add confirmation here
            await ctx.RespondAsync(embed: Embeds.Warning.WithDescription("Deleting channel in 5 seconds"));
            await Task.Delay(5000);
            await ctx.Channel.DeleteAsync();
        }

        [Command("purge")]
        public async Task Purge(CommandContext ctx, int count)
        {
            if (count > 50) throw new UserError("Cannot delete more than 50 messages");
            var allMessages = await ctx.Channel.GetMessagesAsync(count + 1);
            var canDeleteMessages = allMessages;
            if (!(ctx.Message.Author as DiscordMember).PermissionsIn(ctx.Channel).HasPermission(Permissions.ManageMessages))
                canDeleteMessages = allMessages.Where(m => m.Author.Id == ctx.Message.Author.Id).ToList();
            await ctx.Channel.DeleteMessagesAsync(canDeleteMessages);
        }
    }
}