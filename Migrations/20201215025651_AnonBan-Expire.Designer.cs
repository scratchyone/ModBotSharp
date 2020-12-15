﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModBot.Models;

namespace ServerScraper.Migrations
{
    [DbContext(typeof(dataContext))]
    [Migration("20201215025651_AnonBan-Expire")]
    partial class AnonBanExpire
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ModBot.Models.AlertChannel", b =>
                {
                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<string>("Channel")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("channel");

                    b.HasKey("Server");

                    b.ToTable("alert_channels");
                });

            modelBuilder.Entity("ModBot.Models.AlertChannelsIgnore", b =>
                {
                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.HasKey("Server");

                    b.ToTable("alert_channels_ignore");
                });

            modelBuilder.Entity("ModBot.Models.AnonBan", b =>
                {
                    b.Property<string>("User")
                        .HasColumnType("TEXT")
                        .HasColumnName("user");

                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<ulong>("ExpiresAt")
                        .HasColumnType("INTEGER");

                    b.HasKey("User", "Server");

                    b.ToTable("anonbans");
                });

            modelBuilder.Entity("ModBot.Models.Anonchannel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.HasKey("Id", "Server");

                    b.ToTable("anonchannels");
                });

            modelBuilder.Entity("ModBot.Models.Anonmessage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("User")
                        .HasColumnType("TEXT")
                        .HasColumnName("user");

                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.HasKey("Id", "User", "Server");

                    b.ToTable("anonmessages");
                });

            modelBuilder.Entity("ModBot.Models.Automod", b =>
                {
                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<string>("Channel")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("channel");

                    b.HasKey("Server");

                    b.ToTable("automods");
                });

            modelBuilder.Entity("ModBot.Models.AutomodTrigger", b =>
                {
                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("Punishments")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("punishments");

                    b.Property<string>("Regex")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("regex");

                    b.Property<string>("Setuprole")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("setuprole");

                    b.HasKey("Server", "Name");

                    b.ToTable("automod_triggers");
                });

            modelBuilder.Entity("ModBot.Models.Autoresponder", b =>
                {
                    b.Property<string>("Prompt")
                        .HasColumnType("TEXT")
                        .HasColumnName("prompt");

                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<string>("EmbedDescription")
                        .HasColumnType("TEXT")
                        .HasColumnName("embed_description");

                    b.Property<string>("EmbedTitle")
                        .HasColumnType("TEXT")
                        .HasColumnName("embed_title");

                    b.Property<string>("TextResponse")
                        .HasColumnType("TEXT")
                        .HasColumnName("text_response");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("type");

                    b.HasKey("Prompt", "Server");

                    b.ToTable("autoresponders");
                });

            modelBuilder.Entity("ModBot.Models.BotMessage", b =>
                {
                    b.Property<string>("BotMessage1")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("botMessage");

                    b.Property<string>("Channel")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("channel");

                    b.Property<string>("Guild")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("guild");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("message");

                    b.HasIndex(new[] { "BotMessage1" }, "botmessages_botmessage_unique")
                        .IsUnique();

                    b.ToTable("botMessages");
                });

            modelBuilder.Entity("ModBot.Models.Capability", b =>
                {
                    b.Property<long?>("Expire")
                        .HasColumnType("integer")
                        .HasColumnName("expire");

                    b.Property<string>("Token")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("token");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("type");

                    b.Property<string>("User")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user");

                    b.HasIndex(new[] { "Token" }, "capabilities_token_unique")
                        .IsUnique();

                    b.ToTable("capabilities");
                });

            modelBuilder.Entity("ModBot.Models.Defer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("data");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "defers_id_unique")
                        .IsUnique();

                    b.ToTable("defers");
                });

            modelBuilder.Entity("ModBot.Models.DisabledCommand", b =>
                {
                    b.Property<string>("Command")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("command");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("server");

                    b.HasIndex(new[] { "Server", "Command" }, "disabledcommands_server_command_unique")
                        .IsUnique();

                    b.ToTable("disabledCommands");
                });

            modelBuilder.Entity("ModBot.Models.JoinRole", b =>
                {
                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("role");

                    b.HasKey("Server");

                    b.ToTable("join_roles");
                });

            modelBuilder.Entity("ModBot.Models.KnexMigration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<long?>("Batch")
                        .HasColumnType("integer")
                        .HasColumnName("batch");

                    b.Property<byte[]>("MigrationTime")
                        .HasColumnType("datetime")
                        .HasColumnName("migration_time");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("knex_migrations");
                });

            modelBuilder.Entity("ModBot.Models.KnexMigrationsLock", b =>
                {
                    b.Property<long>("Index")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("index");

                    b.Property<long?>("IsLocked")
                        .HasColumnType("integer")
                        .HasColumnName("is_locked");

                    b.HasKey("Index");

                    b.ToTable("knex_migrations_lock");
                });

            modelBuilder.Entity("ModBot.Models.LockedChannel", b =>
                {
                    b.Property<string>("Channel")
                        .HasColumnType("TEXT")
                        .HasColumnName("channel");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("permissions");

                    b.HasKey("Channel");

                    b.ToTable("locked_channels");
                });

            modelBuilder.Entity("ModBot.Models.LogChannel", b =>
                {
                    b.Property<string>("Channel")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("channel");

                    b.Property<string>("Guild")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("guild");

                    b.HasIndex(new[] { "Channel" }, "logchannels_channel_unique")
                        .IsUnique();

                    b.HasIndex(new[] { "Guild" }, "logchannels_guild_unique")
                        .IsUnique();

                    b.ToTable("logChannels");
                });

            modelBuilder.Entity("ModBot.Models.MuteRole", b =>
                {
                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("role");

                    b.HasKey("Server");

                    b.ToTable("mute_roles");
                });

            modelBuilder.Entity("ModBot.Models.Note", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("message");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("type");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("user");

                    b.HasKey("Id");

                    b.ToTable("notes");
                });

            modelBuilder.Entity("ModBot.Models.Pinner", b =>
                {
                    b.Property<string>("Roleid")
                        .HasColumnType("TEXT")
                        .HasColumnName("roleid");

                    b.Property<string>("Guild")
                        .HasColumnType("TEXT")
                        .HasColumnName("guild");

                    b.HasKey("Roleid", "Guild");

                    b.ToTable("pinners");
                });

            modelBuilder.Entity("ModBot.Models.Poll", b =>
                {
                    b.Property<string>("Message")
                        .HasColumnType("TEXT")
                        .HasColumnName("message");

                    b.HasKey("Message");

                    b.ToTable("polls");
                });

            modelBuilder.Entity("ModBot.Models.Prefix", b =>
                {
                    b.Property<string>("PrefixText")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("prefix");

                    b.Property<string>("Server")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("server");

                    b.HasKey("PrefixText", "Server");

                    b.HasIndex(new[] { "Server", "PrefixText" }, "prefixes_server_prefix_unique")
                        .IsUnique();

                    b.ToTable("prefixes");
                });

            modelBuilder.Entity("ModBot.Models.Reactionrole", b =>
                {
                    b.Property<string>("Message")
                        .HasColumnType("TEXT")
                        .HasColumnName("message");

                    b.Property<string>("Emoji")
                        .HasColumnType("TEXT")
                        .HasColumnName("emoji");

                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<byte[]>("Removable")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("undefined")
                        .HasColumnName("removable")
                        .HasDefaultValueSql("'1'");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("role");

                    b.HasKey("Message", "Emoji", "Server");

                    b.ToTable("reactionroles");
                });

            modelBuilder.Entity("ModBot.Models.Reminder", b =>
                {
                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("author");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("text");

                    b.Property<long?>("Time")
                        .HasColumnType("integer")
                        .HasColumnName("time");

                    b.ToTable("reminders");
                });

            modelBuilder.Entity("ModBot.Models.ReminderSubscriber", b =>
                {
                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user");

                    b.ToTable("reminderSubscribers");
                });

            modelBuilder.Entity("ModBot.Models.Slowmode", b =>
                {
                    b.Property<string>("Channel")
                        .HasColumnType("TEXT")
                        .HasColumnName("channel");

                    b.Property<long>("DeleteMm")
                        .HasColumnType("INTEGER")
                        .HasColumnName("delete_mm");

                    b.Property<long>("Time")
                        .HasColumnType("INTEGER")
                        .HasColumnName("time");

                    b.HasKey("Channel");

                    b.ToTable("slowmodes");
                });

            modelBuilder.Entity("ModBot.Models.SlowmodedUser", b =>
                {
                    b.Property<string>("Channel")
                        .HasColumnType("TEXT")
                        .HasColumnName("channel");

                    b.Property<string>("User")
                        .HasColumnType("TEXT")
                        .HasColumnName("user");

                    b.HasKey("Channel", "User");

                    b.ToTable("slowmoded_users");
                });

            modelBuilder.Entity("ModBot.Models.Starboard", b =>
                {
                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<string>("Channel")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("channel");

                    b.Property<long>("Stars")
                        .HasColumnType("INT")
                        .HasColumnName("stars");

                    b.HasKey("Server");

                    b.ToTable("starboards");
                });

            modelBuilder.Entity("ModBot.Models.StarboardMessage", b =>
                {
                    b.Property<string>("Message")
                        .HasColumnType("TEXT")
                        .HasColumnName("message");

                    b.Property<string>("MessageChannel")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("message_channel");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("server");

                    b.Property<string>("StarboardMessage1")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("starboard_message");

                    b.Property<string>("StarboardMessageChannel")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("starboard_message_channel");

                    b.HasKey("Message");

                    b.ToTable("starboard_messages");
                });

            modelBuilder.Entity("ModBot.Models.Subscription", b =>
                {
                    b.Property<string>("Channel")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("channel");

                    b.Property<string>("Guild")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("guild");

                    b.Property<string>("Subreddit")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("subreddit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("type");

                    b.Property<string>("Webhookid")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("webhookid");

                    b.Property<string>("Webhooktoken")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("webhooktoken");

                    b.HasIndex(new[] { "Webhookid" }, "subscriptions_webhookid_unique")
                        .IsUnique();

                    b.HasIndex(new[] { "Webhooktoken" }, "subscriptions_webhooktoken_unique")
                        .IsUnique();

                    b.ToTable("subscriptions");
                });

            modelBuilder.Entity("ModBot.Models.Timerevent", b =>
                {
                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("event");

                    b.Property<long>("Timestamp")
                        .HasColumnType("BIGINT")
                        .HasColumnName("timestamp");

                    b.ToTable("timerevents");
                });
#pragma warning restore 612, 618
        }
    }
}