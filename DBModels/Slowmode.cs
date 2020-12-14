using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("slowmodes")]
    public partial class Slowmode
    {
        [Key]
        [Column("channel")]
        public string Channel { get; set; }
        [Column("time")]
        public long Time { get; set; }
        [Column("delete_mm")]
        public long DeleteMm { get; set; }
    }
}
