using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using ModBot.Models;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace ModBot.Commands
{
    public class Spoil : Cog
    {

        [Command("spoil"), Aliases("spoiler")]
        [Description("Add a spoiler tag to all attachments of a message")]
        [RequireBotPermissions(Permissions.ManageWebhooks)]
        public async Task SpoilCommand(CommandContext ctx, [Description("The message text"), RemainingText] string content)
        {
            var message = new DiscordWebhookBuilder();
            foreach (var attachment in ctx.Message.Attachments)
            {
                message.AddFile("SPOILER_" + attachment.FileName, GetStreamFromUrl(attachment.Url));
            }
            message.WithContent(content);
            message.WithAvatarUrl(ctx.Member.GetAvatarUrl(ImageFormat.Auto));
            message.WithUsername(ctx.Member.DisplayName);
            var webhook = (await ctx.Channel.GetWebhooksAsync()).FirstOrDefault();
            if (webhook == null) webhook = await ctx.Channel.CreateWebhookAsync("SpoilHook");
            await webhook.ExecuteAsync(message);
        }
        private static Stream GetStreamFromUrl(string url)
        {
            byte[] imageData = null;

            using (var wc = new System.Net.WebClient())
                imageData = wc.DownloadData(url);

            return new MemoryStream(imageData);
        }

    }
}