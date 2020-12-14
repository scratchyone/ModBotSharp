using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Keyless]
    [Table("botMessages")]
    [Index(nameof(BotMessage1), Name = "botmessages_botmessage_unique", IsUnique = true)]
    public partial class BotMessage
    {
        [Required]
        [Column("guild", TypeName = "varchar(255)")]
        public string Guild { get; set; }
        [Required]
        [Column("channel", TypeName = "varchar(255)")]
        public string Channel { get; set; }
        [Required]
        [Column("message", TypeName = "varchar(255)")]
        public string Message { get; set; }
        [Required]
        [Column("botMessage", TypeName = "varchar(255)")]
        public string BotMessage1 { get; set; }
    }
}
