using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("autoresponders")]
    public partial class Autoresponder
    {
        [Key]
        [Column("prompt")]
        public string Prompt { get; set; }
        [Required]
        [Column("type")]
        public string Type { get; set; }
        [Column("text_response")]
        public string TextResponse { get; set; }
        [Column("embed_title")]
        public string EmbedTitle { get; set; }
        [Column("embed_description")]
        public string EmbedDescription { get; set; }
        [Key]
        [Column("server")]
        public string Server { get; set; }
    }
}
