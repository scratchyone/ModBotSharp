using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("automod_triggers")]
    public partial class AutomodTrigger
    {
        [Key]
        [Column("server")]
        public string Server { get; set; }
        [Required]
        [Column("setuprole")]
        public string Setuprole { get; set; }
        [Key]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("regex")]
        public string Regex { get; set; }
        [Required]
        [Column("punishments")]
        public string Punishments { get; set; }
    }
}
