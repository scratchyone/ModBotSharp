using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("anonmessages")]
    public partial class Anonmessage
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        [Key]
        [Column("user")]
        public string User { get; set; }
        [Key]
        [Column("server")]
        public string Server { get; set; }
    }
}
