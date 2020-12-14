using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("starboards")]
    public partial class Starboard
    {
        [Required]
        [Column("channel")]
        public string Channel { get; set; }
        [Key]
        [Column("server")]
        public string Server { get; set; }
        [Column("stars", TypeName = "INT")]
        public long Stars { get; set; }
    }
}
