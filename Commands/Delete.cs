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
        [Description("Delete the current channel")]
        [RequireUserPermissions(Permissions.ManageChannels)]
        public async Task DeleteChannel(CommandContext ctx)
        {
            if (await ctx.Confirm())
            {
                await ctx.RespondAsync(embed: Embeds.Warning.WithDescription("Deleting channel in 5 seconds"));
                await Task.Delay(5000);
                await ctx.Channel.DeleteAsync();
            }
        }

        [Command("purge")]
        [Description("Delete up to 50 messages from the current channel")]
        public async Task Purge(CommandContext ctx, [Description("Number of messages to delete")] int count)
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