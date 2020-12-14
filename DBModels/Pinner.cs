using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("pinners")]
    public partial class Pinner
    {
        [Key]
        [Column("roleid")]
        public string Roleid { get; set; }
        [Key]
        [Column("guild")]
        public string Guild { get; set; }
    }
}
