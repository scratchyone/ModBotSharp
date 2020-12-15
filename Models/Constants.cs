using DSharpPlus.Entities;

namespace ModBot
{
    class Colors
    {
        public static DiscordColor Info = new DiscordColor("#1da0ff");
        public static DiscordColor Success = new DiscordColor("#1dbb4f");
        public static DiscordColor Error = new DiscordColor("#e74d4d");
        public static DiscordColor Warning = new DiscordColor("#d8ae2b");
    }
    class Embeds
    {
        public readonly static DiscordEmbedBuilder Success = new DiscordEmbedBuilder().WithTitle("Success!").WithColor(Colors.Success);
        public readonly static DiscordEmbedBuilder Error = new DiscordEmbedBuilder().WithTitle("Error").WithColor(Colors.Error);
        public readonly static DiscordEmbedBuilder Warning = new DiscordEmbedBuilder().WithTitle("Warning!").WithColor(Colors.Warning);
        public readonly static DiscordEmbedBuilder Info = new DiscordEmbedBuilder().WithTitle("Info!").WithColor(Colors.Info);
    }
}