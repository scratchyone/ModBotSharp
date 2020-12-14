using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("anonbans")]
    public partial class AnonBan
    {
        [Key]
        [Column("user")]
        public string User { get; set; }
        [Key]
        [Column("server")]
        public string Server { get; set; }
    }
}
