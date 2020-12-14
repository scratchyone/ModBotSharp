using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Keyless]
    [Table("disabledCommands")]
    [Index(nameof(Server), nameof(Command), Name = "disabledcommands_server_command_unique", IsUnique = true)]
    public partial class DisabledCommand
    {
        [Required]
        [Column("server", TypeName = "varchar(255)")]
        public string Server { get; set; }
        [Required]
        [Column("command", TypeName = "varchar(255)")]
        public string Command { get; set; }
    }
}
