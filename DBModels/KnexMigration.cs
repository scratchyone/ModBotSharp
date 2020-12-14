using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ModBot.Models
{
    [Table("knex_migrations")]
    public partial class KnexMigration
    {
        [Key]
        [Column("id", TypeName = "integer")]
        public long Id { get; set; }
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Column("batch", TypeName = "integer")]
        public long? Batch { get; set; }
        [Column("migration_time", TypeName = "datetime")]
        public byte[] MigrationTime { get; set; }
    }
}
