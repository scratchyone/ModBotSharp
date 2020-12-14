using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("alert_channels")]
    public partial class AlertChannel
    {
        [Key]
        [Column("server")]
        public string Server { get; set; }
        [Required]
        [Column("channel")]
        public string Channel { get; set; }
    }
}
