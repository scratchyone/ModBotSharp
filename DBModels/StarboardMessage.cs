using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("starboard_messages")]
    public partial class StarboardMessage
    {
        [Key]
        [Column("message")]
        public string Message { get; set; }
        [Required]
        [Column("starboard_message")]
        public string StarboardMessage1 { get; set; }
        [Required]
        [Column("server")]
        public string Server { get; set; }
        [Required]
        [Column("starboard_message_channel")]
        public string StarboardMessageChannel { get; set; }
        [Required]
        [Column("message_channel")]
        public string MessageChannel { get; set; }
    }
}
