using DSharpPlus;

namespace ModBot
{
    public static class Extensions
    {
        public static string CreateInvite(this DiscordClient client)
        {
            return $"https://discord.com/api/oauth2/authorize?client_id={client.CurrentUser.Id}&permissions=2146958847&scope=bot";
        }
    }
}