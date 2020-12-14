using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Keyless]
    [Table("prefixes")]
    [Index(nameof(Server), nameof(PrefixText), Name = "prefixes_server_prefix_unique", IsUnique = true)]
    public partial class Prefix
    {
        [Required]
        [Column("server", TypeName = "varchar(255)")]
        public string Server { get; set; }
        [Required]
        [Column("prefix", TypeName = "varchar(10)")]
        public string PrefixText { get; set; }
    }
}
