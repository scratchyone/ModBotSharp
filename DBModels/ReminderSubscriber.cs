using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Keyless]
    [Table("reminderSubscribers")]
    public partial class ReminderSubscriber
    {
        [Required]
        [Column("user", TypeName = "varchar(255)")]
        public string User { get; set; }
        [Required]
        [Column("id", TypeName = "varchar(255)")]
        public string Id { get; set; }
    }
}
