using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("reactionroles")]
    public partial class Reactionrole
    {
        [Key]
        [Column("message")]
        public string Message { get; set; }
        [Key]
        [Column("server")]
        public string Server { get; set; }
        [Key]
        [Column("emoji")]
        public string Emoji { get; set; }
        [Required]
        [Column("role")]
        public string Role { get; set; }
        [Required]
        [Column("removable", TypeName = "undefined")]
        public byte[] Removable { get; set; }
    }
}
