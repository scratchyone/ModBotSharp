using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("mute_roles")]
    public partial class MuteRole
    {
        [Required]
        [Column("role")]
        public string Role { get; set; }
        [Key]
        [Column("server")]
        public string Server { get; set; }
    }
}
