using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Keyless]
    [Table("reminders")]
    public partial class Reminder
    {
        [Required]
        [Column("author", TypeName = "varchar(255)")]
        public string Author { get; set; }
        [Required]
        [Column("id", TypeName = "varchar(255)")]
        public string Id { get; set; }
        [Column("text", TypeName = "varchar(255)")]
        public string Text { get; set; }
        [Column("time", TypeName = "integer")]
        public long? Time { get; set; }
    }
}
