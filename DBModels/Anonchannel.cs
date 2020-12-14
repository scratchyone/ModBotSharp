using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("anonchannels")]
    public partial class Anonchannel
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        [Key]
        [Column("server")]
        public string Server { get; set; }
    }
}
