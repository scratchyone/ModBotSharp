using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("polls")]
    public partial class Poll
    {
        [Key]
        [Column("message")]
        public string Message { get; set; }
    }
}
