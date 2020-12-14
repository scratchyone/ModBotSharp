using System.IO;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using ModBot.Models;
using ModBot.Commands;
using DSharp​Plus.CommandsNext;

namespace ModBot
{
    class Program
    {
        static private IConfiguration Configuration;
        static private dataContext context;
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            context = new dataContext();
            MainAsync().GetAwaiter().GetResult();

        }
        // Registers all command modules
        static void RegisterCommands(ref CommandsNextExtension commands)
        {
            commands.RegisterCommands<Prefixes>();
            Prefixes.OnStart(commands.Client);
        }
        static async Task<int> PrefixResolver(DiscordMessage message, DiscordUser client)
        {
            var mentionPrefixLength = CommandsNextUtilities.GetMentionPrefixLength(message, client);
            if (mentionPrefixLength != -1) return mentionPrefixLength;
            var prefixes = context.Prefixes.Where(prefix => prefix.Server == message.Channel.GuildId.ToString())
                .Select(prefix => prefix.PrefixText).OrderByDescending(prefix => prefix.Length).ToList();
            prefixes.Add("m: ");
            foreach (var prefix in prefixes)
            {
                var prefixLength = CommandsNextUtilities.GetStringPrefixLength(message, prefix);
                if (prefixLength != -1) return prefixLength;
            }
            return -1;
        }
        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = Configuration["Token"],
                TokenType = TokenType.Bot
            });
            var services = new ServiceCollection()
                .AddSingleton<dataContext>()
                .BuildServiceProvider();
            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                Services = services,
                PrefixResolver = (m) => PrefixResolver(m, discord.CurrentUser)
            });
            RegisterCommands(ref commands);
            commands.CommandErrored += async (ex, er) =>
            {
                discord.Logger.LogError(er.Exception.ToString());
                if (er.Exception is ModBot.UserError)
                {
                    await er.Context.RespondAsync(embed: Embeds.Error
                        .WithFooter($"Use {er.Context.Prefix}support to get an invite to the support server")
                        .WithDescription(er.Exception.Message));
                }
            };
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }

}
