using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("slowmoded_users")]
    public partial class SlowmodedUser
    {
        [Key]
        [Column("channel")]
        public string Channel { get; set; }
        [Key]
        [Column("user")]
        public string User { get; set; }
    }
}
