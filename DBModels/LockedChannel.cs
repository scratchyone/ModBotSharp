using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("locked_channels")]
    public partial class LockedChannel
    {
        [Key]
        [Column("channel")]
        public string Channel { get; set; }
        [Required]
        [Column("permissions")]
        public string Permissions { get; set; }
    }
}
