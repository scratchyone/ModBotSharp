using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("join_roles")]
    public partial class JoinRole
    {
        [Key]
        [Column("server")]
        public string Server { get; set; }
        [Required]
        [Column("role")]
        public string Role { get; set; }
    }
}
