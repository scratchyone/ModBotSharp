using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Keyless]
    [Table("logChannels")]
    [Index(nameof(Channel), Name = "logchannels_channel_unique", IsUnique = true)]
    [Index(nameof(Guild), Name = "logchannels_guild_unique", IsUnique = true)]
    public partial class LogChannel
    {
        [Required]
        [Column("guild", TypeName = "varchar(255)")]
        public string Guild { get; set; }
        [Required]
        [Column("channel", TypeName = "varchar(255)")]
        public string Channel { get; set; }
    }
}
