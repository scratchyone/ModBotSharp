using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Keyless]
    [Table("capabilities")]
    [Index(nameof(Token), Name = "capabilities_token_unique", IsUnique = true)]
    public partial class Capability
    {
        [Column("token", TypeName = "varchar(255)")]
        public string Token { get; set; }
        [Column("user", TypeName = "varchar(255)")]
        public string User { get; set; }
        [Column("type", TypeName = "varchar(255)")]
        public string Type { get; set; }
        [Column("expire", TypeName = "integer")]
        public long? Expire { get; set; }
    }
}
