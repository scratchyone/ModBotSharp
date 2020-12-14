using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Keyless]
    [Table("subscriptions")]
    [Index(nameof(Webhookid), Name = "subscriptions_webhookid_unique", IsUnique = true)]
    [Index(nameof(Webhooktoken), Name = "subscriptions_webhooktoken_unique", IsUnique = true)]
    public partial class Subscription
    {
        [Required]
        [Column("type", TypeName = "varchar(255)")]
        public string Type { get; set; }
        [Column("subreddit", TypeName = "varchar(255)")]
        public string Subreddit { get; set; }
        [Required]
        [Column("webhookid", TypeName = "varchar(255)")]
        public string Webhookid { get; set; }
        [Required]
        [Column("webhooktoken", TypeName = "varchar(255)")]
        public string Webhooktoken { get; set; }
        [Required]
        [Column("guild", TypeName = "varchar(255)")]
        public string Guild { get; set; }
        [Required]
        [Column("channel", TypeName = "varchar(255)")]
        public string Channel { get; set; }
    }
}
