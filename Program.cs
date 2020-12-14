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
using DSharpPlus.CommandsNext.Exceptions;

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
            commands.RegisterCommands<Meta>();
            commands.RegisterCommands<Rename>();
        }
        static Task<int> PrefixResolver(DiscordMessage message, DiscordUser client)
        {
            var mentionPrefixLength = CommandsNextUtilities.GetMentionPrefixLength(message, client);
            if (mentionPrefixLength != -1) return Task.FromResult(mentionPrefixLength);
            var prefixes = context.Prefixes.Where(prefix => prefix.Server == message.Channel.GuildId.ToString())
                .Select(prefix => prefix.PrefixText).OrderByDescending(prefix => prefix.Length).ToList();
            prefixes.Add(Configuration["Prefix"]);
            foreach (var prefix in prefixes)
            {
                var prefixLength = CommandsNextUtilities.GetStringPrefixLength(message, prefix);
                if (prefixLength != -1) return Task.FromResult(prefixLength);
            }
            return Task.FromResult(-1);
        }
        static async Task HandleErrors(CommandsNextExtension ex, CommandErrorEventArgs er, DiscordClient client)
        {
            client.Logger.LogError(er.Exception.ToString());
            if (er.Exception is ModBot.UserError)
            {
                await er.Context.RespondAsync(embed: Embeds.Error
                    .WithFooter($"Use {er.Context.Prefix}support to get an invite to the support server")
                    .WithDescription(er.Exception.Message));
            }
            if (er.Exception is ChecksFailedException)
            {
                foreach (var check in (er.Exception as ChecksFailedException).FailedChecks)
                {
                    if (check is RequireUserPermissionsAttribute)
                    {
                        await er.Context.RespondAsync(embed: Embeds.Error
                            .WithFooter($"Use {er.Context.Prefix}support to get an invite to the support server")
                            .WithDescription($"You need {(check as RequireUserPermissionsAttribute).Permissions.ToString()} to run that command."));
                    }
                }
            }
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
                .AddSingleton<IConfiguration>(Configuration)
                .BuildServiceProvider();
            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                Services = services,
                PrefixResolver = (m) => PrefixResolver(m, discord.CurrentUser)
            });
            RegisterCommands(ref commands);
            commands.CommandErrored += (a, b) => HandleErrors(a, b, discord);
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }

}
