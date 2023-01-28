using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ArgonDashboard.Core.Patterns.Repositroy;

namespace ArgonDashboard.Core.Data.Entities
{
    [Table("roles")]
    [Index(nameof(Name), Name = "roles_name_unique", IsUnique = true)]
    public partial class Role : IdentityRole<long>, IEntity<long>
    {
        [Column("is_active")]
        [System.ComponentModel.DefaultValue(null)]
        public bool IsActive { get; set; }

        [AllowNull]
        [Column("created_by")]
        public long? CreatedBy { get; set; }

        [AllowNull]
        [Column("updated_by")]
        public long? UpdatedBy { get; set; }

        [AllowNull]
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [AllowNull]
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [AllowNull]
        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
