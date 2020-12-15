using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using ModBot.Models;

namespace ModBot.Commands
{
    public class Avatar : Cog
    {

        [Command("avatar"), Aliases("profilepic", "pfp")]
        [Description("Get a user's profile picture")]
        public async Task AvatarCommand(CommandContext ctx, [Description("The user to get the profile picture of")] DiscordMember user)
        {
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                .WithImageUrl(user.GetAvatarUrl(ImageFormat.Auto, size: 256))
                .WithTitle(user.DisplayName + "'s Profile Picture"));
        }
        [Command("avatar")]
        public async Task AvatarCommand(CommandContext ctx, [Description("The user to get the profile picture of")] DiscordUser user)
        {
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                .WithImageUrl(user.GetAvatarUrl(ImageFormat.Auto, size: 256))
                .WithTitle(user.Username + "'s Profile Picture"));
        }
    }
}