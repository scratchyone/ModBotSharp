using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Keyless]
    [Table("timerevents")]
    public partial class Timerevent
    {
        [Column("timestamp", TypeName = "BIGINT")]
        public long Timestamp { get; set; }
        [Required]
        [Column("event")]
        public string Event { get; set; }
    }
}
