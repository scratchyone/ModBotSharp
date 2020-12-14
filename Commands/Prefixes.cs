using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Linq;
using ModBot.Models;

namespace ModBot.Commands
{
    [RequireGuild]
    [Group("prefixes"), Aliases("prefix")]
    public class Prefixes : Cog
    {
        public dataContext context { private get; set; }

        [Command("list")]
        public async Task List(CommandContext ctx)
        {
            var prefixes = context.Prefixes.Where(p => p.Server == ctx.Message.Channel.GuildId.ToString()).Select(p => p.PrefixText).ToList();
            prefixes.Add("m: ");
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder().WithTitle("Prefixes")
                .WithColor(ModBot.Colors.Info)
                .WithDescription(string.Join("\n", prefixes.Select(p => $"`{p}`"))));
        }
        [Command("add")]
        [RequireUserPermissions(Permissions.ManageMessages)]
        public async Task Add(CommandContext ctx, [RemainingText] string prefix)
        {
            var existingPrefix = context.Prefixes.FirstOrDefault(p => p.PrefixText == prefix && p.Server == ctx.Channel.GuildId.ToString());
            if (prefix.Length > 10) throw new UserError("Prefix must be less than 10 characters");
            if (existingPrefix != null) throw new UserError("Prefix already exists");
            await context.Prefixes.AddAsync(new Prefix { Server = ctx.Channel.GuildId.ToString(), PrefixText = prefix });
            await context.SaveChangesAsync();
            await ctx.RespondAsync(embed: Embeds.Success.WithDescription("Prefix added!"));
        }
        [Command("remove")]
        [RequireUserPermissions(Permissions.ManageMessages)]
        public async Task Remove(CommandContext ctx, [RemainingText] string prefix)
        {
            var existingPrefix = context.Prefixes.SingleOrDefault(p => p.PrefixText == prefix && p.Server == ctx.Channel.GuildId.ToString());
            if (existingPrefix == null)
                throw new UserError("Prefix not found");
            context.Prefixes.Remove(existingPrefix);
            await context.SaveChangesAsync();
            await ctx.RespondAsync(embed: Embeds.Success.WithDescription("Prefix removed!"));
        }
    }
}