using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("notes")]
    public partial class Note
    {
        [Required]
        [Column("type")]
        public string Type { get; set; }
        [Required]
        [Column("message")]
        public string Message { get; set; }
        [Required]
        [Column("user")]
        public string User { get; set; }
        [Required]
        [Column("server")]
        public string Server { get; set; }
        [Key]
        [Column("id")]
        public string Id { get; set; }
    }
}
