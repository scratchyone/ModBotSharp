using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ModBot.Models
{
    public partial class dataContext : DbContext
    {
        public dataContext()
        {
        }

        public dataContext(DbContextOptions<dataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlertChannel> AlertChannels { get; set; }
        public virtual DbSet<AlertChannelsIgnore> AlertChannelsIgnores { get; set; }
        public virtual DbSet<AnonBan> AnonBans { get; set; }
        public virtual DbSet<Anonchannel> Anonchannels { get; set; }
        public virtual DbSet<Anonmessage> Anonmessages { get; set; }
        public virtual DbSet<Automod> Automods { get; set; }
        public virtual DbSet<AutomodTrigger> AutomodTriggers { get; set; }
        public virtual DbSet<Autoresponder> Autoresponders { get; set; }
        public virtual DbSet<BotMessage> BotMessages { get; set; }
        public virtual DbSet<Capability> Capabilities { get; set; }
        public virtual DbSet<Defer> Defers { get; set; }
        public virtual DbSet<DisabledCommand> DisabledCommands { get; set; }
        public virtual DbSet<JoinRole> JoinRoles { get; set; }
        public virtual DbSet<KnexMigration> KnexMigrations { get; set; }
        public virtual DbSet<KnexMigrationsLock> KnexMigrationsLocks { get; set; }
        public virtual DbSet<LockedChannel> LockedChannels { get; set; }
        public virtual DbSet<LogChannel> LogChannels { get; set; }
        public virtual DbSet<MuteRole> MuteRoles { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Pinner> Pinners { get; set; }
        public virtual DbSet<Poll> Polls { get; set; }
        public virtual DbSet<Prefix> Prefixes { get; set; }
        public virtual DbSet<Reactionrole> Reactionroles { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }
        public virtual DbSet<ReminderSubscriber> ReminderSubscribers { get; set; }
        public virtual DbSet<Slowmode> Slowmodes { get; set; }
        public virtual DbSet<SlowmodedUser> SlowmodedUsers { get; set; }
        public virtual DbSet<Starboard> Starboards { get; set; }
        public virtual DbSet<StarboardMessage> StarboardMessages { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Timerevent> Timerevents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=data.db3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnonBan>(entity =>
            {
                entity.HasKey(e => new { e.User, e.Server });
            });

            modelBuilder.Entity<Anonchannel>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Server });
            });

            modelBuilder.Entity<Anonmessage>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.User, e.Server });
            });

            modelBuilder.Entity<AutomodTrigger>(entity =>
            {
                entity.HasKey(e => new { e.Server, e.Name });
            });

            modelBuilder.Entity<Autoresponder>(entity =>
            {
                entity.HasKey(e => new { e.Prompt, e.Server });
            });

            modelBuilder.Entity<Pinner>(entity =>
            {
                entity.HasKey(e => new { e.Roleid, e.Guild });
            });

            modelBuilder.Entity<Reactionrole>(entity =>
            {
                entity.HasKey(e => new { e.Message, e.Emoji, e.Server });

                entity.Property(e => e.Removable).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<SlowmodedUser>(entity =>
            {
                entity.HasKey(e => new { e.Channel, e.User });
            });

            modelBuilder.Entity<Prefix>(entity =>
            {
                entity.HasKey(e => new { e.PrefixText, e.Server });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
