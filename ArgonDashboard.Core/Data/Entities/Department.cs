using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

#nullable disable

namespace ArgonDashboard.Core.Data.Entities
{
    [Table("departments")]
    [Index(nameof(Name), Name = "department_name_unique", IsUnique = true)]
    public partial class Department : BaseEntity
    {
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Column("is_ldap")]
        [System.ComponentModel.DefaultValue(null)]
        public bool IsLdap { get; set; }

        [Column("is_active")]
        [System.ComponentModel.DefaultValue(null)]
        public bool IsActive { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        [NotMapped]
        public int UsersCount { get; set; }
    }
}
