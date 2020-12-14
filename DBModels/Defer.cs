using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("defers")]
    [Index(nameof(Id), Name = "defers_id_unique", IsUnique = true)]
    public partial class Defer
    {
        [Key]
        [Column("id", TypeName = "varchar(255)")]
        public string Id { get; set; }
        [Required]
        [Column("data", TypeName = "varchar(255)")]
        public string Data { get; set; }
    }
}
