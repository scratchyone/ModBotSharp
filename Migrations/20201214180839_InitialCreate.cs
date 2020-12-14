using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerScraper.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alert_channels",
                columns: table => new
                {
                    server = table.Column<string>(type: "TEXT", nullable: false),
                    channel = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alert_channels", x => x.server);
                });

            migrationBuilder.CreateTable(
                name: "alert_channels_ignore",
                columns: table => new
                {
                    server = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alert_channels_ignore", x => x.server);
                });

            migrationBuilder.CreateTable(
                name: "anonbans",
                columns: table => new
                {
                    user = table.Column<string>(type: "TEXT", nullable: false),
                    server = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anonbans", x => new { x.user, x.server });
                });

            migrationBuilder.CreateTable(
                name: "anonchannels",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    server = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anonchannels", x => new { x.id, x.server });
                });

            migrationBuilder.CreateTable(
                name: "anonmessages",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    user = table.Column<string>(type: "TEXT", nullable: false),
                    server = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anonmessages", x => new { x.id, x.user, x.server });
                });

            migrationBuilder.CreateTable(
                name: "automod_triggers",
                columns: table => new
                {
                    server = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    setuprole = table.Column<string>(type: "TEXT", nullable: false),
                    regex = table.Column<string>(type: "TEXT", nullable: false),
                    punishments = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_automod_triggers", x => new { x.server, x.name });
                });

            migrationBuilder.CreateTable(
                name: "automods",
                columns: table => new
                {
                    server = table.Column<string>(type: "TEXT", nullable: false),
                    channel = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_automods", x => x.server);
                });

            migrationBuilder.CreateTable(
                name: "autoresponders",
                columns: table => new
                {
                    prompt = table.Column<string>(type: "TEXT", nullable: false),
                    server = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    text_response = table.Column<string>(type: "TEXT", nullable: true),
                    embed_title = table.Column<string>(type: "TEXT", nullable: true),
                    embed_description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autoresponders", x => new { x.prompt, x.server });
                });

            migrationBuilder.CreateTable(
                name: "botMessages",
                columns: table => new
                {
                    guild = table.Column<string>(type: "varchar(255)", nullable: false),
                    channel = table.Column<string>(type: "varchar(255)", nullable: false),
                    message = table.Column<string>(type: "varchar(255)", nullable: false),
                    botMessage = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "capabilities",
                columns: table => new
                {
                    token = table.Column<string>(type: "varchar(255)", nullable: true),
                    user = table.Column<string>(type: "varchar(255)", nullable: true),
                    type = table.Column<string>(type: "varchar(255)", nullable: true),
                    expire = table.Column<long>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "defers",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false),
                    data = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_defers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "disabledCommands",
                columns: table => new
                {
                    server = table.Column<string>(type: "varchar(255)", nullable: false),
                    command = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "join_roles",
                columns: table => new
                {
                    server = table.Column<string>(type: "TEXT", nullable: false),
                    role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_join_roles", x => x.server);
                });

            migrationBuilder.CreateTable(
                name: "knex_migrations",
                columns: table => new
                {
                    id = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "varchar(255)", nullable: true),
                    batch = table.Column<long>(type: "integer", nullable: true),
                    migration_time = table.Column<byte[]>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_knex_migrations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "knex_migrations_lock",
                columns: table => new
                {
                    index = table.Column<long>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    is_locked = table.Column<long>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_knex_migrations_lock", x => x.index);
                });

            migrationBuilder.CreateTable(
                name: "locked_channels",
                columns: table => new
                {
                    channel = table.Column<string>(type: "TEXT", nullable: false),
                    permissions = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locked_channels", x => x.channel);
                });

            migrationBuilder.CreateTable(
                name: "logChannels",
                columns: table => new
                {
                    guild = table.Column<string>(type: "varchar(255)", nullable: false),
                    channel = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "mute_roles",
                columns: table => new
                {
                    server = table.Column<string>(type: "TEXT", nullable: false),
                    role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mute_roles", x => x.server);
                });

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    message = table.Column<string>(type: "TEXT", nullable: false),
                    user = table.Column<string>(type: "TEXT", nullable: false),
                    server = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pinners",
                columns: table => new
                {
                    roleid = table.Column<string>(type: "TEXT", nullable: false),
                    guild = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pinners", x => new { x.roleid, x.guild });
                });

            migrationBuilder.CreateTable(
                name: "polls",
                columns: table => new
                {
                    message = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_polls", x => x.message);
                });

            migrationBuilder.CreateTable(
                name: "prefixes",
                columns: table => new
                {
                    server = table.Column<string>(type: "varchar(255)", nullable: false),
                    prefix = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "reactionroles",
                columns: table => new
                {
                    message = table.Column<string>(type: "TEXT", nullable: false),
                    server = table.Column<string>(type: "TEXT", nullable: false),
                    emoji = table.Column<string>(type: "TEXT", nullable: false),
                    role = table.Column<string>(type: "TEXT", nullable: false),
                    removable = table.Column<byte[]>(type: "undefined", nullable: false, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reactionroles", x => new { x.message, x.emoji, x.server });
                });

            migrationBuilder.CreateTable(
                name: "reminders",
                columns: table => new
                {
                    author = table.Column<string>(type: "varchar(255)", nullable: false),
                    id = table.Column<string>(type: "varchar(255)", nullable: false),
                    text = table.Column<string>(type: "varchar(255)", nullable: true),
                    time = table.Column<long>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "reminderSubscribers",
                columns: table => new
                {
                    user = table.Column<string>(type: "varchar(255)", nullable: false),
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "slowmoded_users",
                columns: table => new
                {
                    channel = table.Column<string>(type: "TEXT", nullable: false),
                    user = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slowmoded_users", x => new { x.channel, x.user });
                });

            migrationBuilder.CreateTable(
                name: "slowmodes",
                columns: table => new
                {
                    channel = table.Column<string>(type: "TEXT", nullable: false),
                    time = table.Column<long>(type: "INTEGER", nullable: false),
                    delete_mm = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slowmodes", x => x.channel);
                });

            migrationBuilder.CreateTable(
                name: "starboard_messages",
                columns: table => new
                {
                    message = table.Column<string>(type: "TEXT", nullable: false),
                    starboard_message = table.Column<string>(type: "TEXT", nullable: false),
                    server = table.Column<string>(type: "TEXT", nullable: false),
                    starboard_message_channel = table.Column<string>(type: "TEXT", nullable: false),
                    message_channel = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_starboard_messages", x => x.message);
                });

            migrationBuilder.CreateTable(
                name: "starboards",
                columns: table => new
                {
                    server = table.Column<string>(type: "TEXT", nullable: false),
                    channel = table.Column<string>(type: "TEXT", nullable: false),
                    stars = table.Column<long>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_starboards", x => x.server);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    type = table.Column<string>(type: "varchar(255)", nullable: false),
                    subreddit = table.Column<string>(type: "varchar(255)", nullable: true),
                    webhookid = table.Column<string>(type: "varchar(255)", nullable: false),
                    webhooktoken = table.Column<string>(type: "varchar(255)", nullable: false),
                    guild = table.Column<string>(type: "varchar(255)", nullable: false),
                    channel = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "timerevents",
                columns: table => new
                {
                    timestamp = table.Column<long>(type: "BIGINT", nullable: false),
                    @event = table.Column<string>(name: "event", type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "botmessages_botmessage_unique",
                table: "botMessages",
                column: "botMessage",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "capabilities_token_unique",
                table: "capabilities",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "defers_id_unique",
                table: "defers",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "disabledcommands_server_command_unique",
                table: "disabledCommands",
                columns: new[] { "server", "command" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "logchannels_channel_unique",
                table: "logChannels",
                column: "channel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "logchannels_guild_unique",
                table: "logChannels",
                column: "guild",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "prefixes_server_prefix_unique",
                table: "prefixes",
                columns: new[] { "server", "prefix" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "subscriptions_webhookid_unique",
                table: "subscriptions",
                column: "webhookid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "subscriptions_webhooktoken_unique",
                table: "subscriptions",
                column: "webhooktoken",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alert_channels");

            migrationBuilder.DropTable(
                name: "alert_channels_ignore");

            migrationBuilder.DropTable(
                name: "anonbans");

            migrationBuilder.DropTable(
                name: "anonchannels");

            migrationBuilder.DropTable(
                name: "anonmessages");

            migrationBuilder.DropTable(
                name: "automod_triggers");

            migrationBuilder.DropTable(
                name: "automods");

            migrationBuilder.DropTable(
                name: "autoresponders");

            migrationBuilder.DropTable(
                name: "botMessages");

            migrationBuilder.DropTable(
                name: "capabilities");

            migrationBuilder.DropTable(
                name: "defers");

            migrationBuilder.DropTable(
                name: "disabledCommands");

            migrationBuilder.DropTable(
                name: "join_roles");

            migrationBuilder.DropTable(
                name: "knex_migrations");

            migrationBuilder.DropTable(
                name: "knex_migrations_lock");

            migrationBuilder.DropTable(
                name: "locked_channels");

            migrationBuilder.DropTable(
                name: "logChannels");

            migrationBuilder.DropTable(
                name: "mute_roles");

            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropTable(
                name: "pinners");

            migrationBuilder.DropTable(
                name: "polls");

            migrationBuilder.DropTable(
                name: "prefixes");

            migrationBuilder.DropTable(
                name: "reactionroles");

            migrationBuilder.DropTable(
                name: "reminders");

            migrationBuilder.DropTable(
                name: "reminderSubscribers");

            migrationBuilder.DropTable(
                name: "slowmoded_users");

            migrationBuilder.DropTable(
                name: "slowmodes");

            migrationBuilder.DropTable(
                name: "starboard_messages");

            migrationBuilder.DropTable(
                name: "starboards");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "timerevents");
        }
    }
}
