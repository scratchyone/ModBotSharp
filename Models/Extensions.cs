using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity.Extensions;
using System.Threading.Tasks;
using System;
namespace ModBot
{
    public static class Extensions
    {
        public static string CreateInvite(this DiscordClient client)
        {
            return $"https://discord.com/api/oauth2/authorize?client_id={client.CurrentUser.Id}&permissions=2146958847&scope=bot";
        }
        public static async Task<bool> Confirm(this CommandContext ctx)
        {
            var emoji = DiscordEmoji.FromName(ctx.Client, ":white_check_mark:");
            var message = await ctx.RespondAsync(embed: Embeds.Warning.WithTitle("Are you sure?").WithDescription("React with :white_check_mark: to confirm."));
            await message.CreateReactionAsync(emoji);
            var result = await message.WaitForReactionAsync(ctx.Member, emoji, TimeSpan.FromSeconds(10));
            if (!result.TimedOut)
            {
                await message.ModifyAsync(embed: Embeds.Success.WithTitle("Confirmation Successful").Build());
                await message.DeleteAllReactionsAsync();
                return true;
            }
            else
            {
                await message.ModifyAsync(embed: Embeds.Error.WithTitle("Confirmation Failed").Build());
                await message.DeleteAllReactionsAsync();
                return false;
            }
        }
    }
}