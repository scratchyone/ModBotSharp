using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("knex_migrations_lock")]
    public partial class KnexMigrationsLock
    {
        [Key]
        [Column("index", TypeName = "integer")]
        public long Index { get; set; }
        [Column("is_locked", TypeName = "integer")]
        public long? IsLocked { get; set; }
    }
}
