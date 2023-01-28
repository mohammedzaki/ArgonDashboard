using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using ArgonDashboard.Core.Patterns.Repositroy;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Swashbuckle.AspNetCore.Annotations;

namespace ArgonDashboard.Core.Data.Entities
{
    public abstract class BaseEntity : IEntity<long>
    {
        [Key]
        [Column("id")]
        [SwaggerSchema("The entity identifier", ReadOnly = true)]
        public long Id { get; set; }

        [Column("created_by")]
        [AllowNull]
        [SwaggerSchema(ReadOnly = true)]
        public long? CreatedBy { get; set; }

        [Column("updated_by")]
        [AllowNull]
        [SwaggerSchema(ReadOnly = true)]
        public long? UpdatedBy { get; set; }

        [Column("created_at")]
        [AllowNull]
        [SwaggerSchema(ReadOnly = true)]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        [AllowNull]
        [SwaggerSchema(ReadOnly = true)]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        [AllowNull]
        [SwaggerSchema(ReadOnly = true)]
        public DateTime? DeletedAt { get; set; }

        protected ILazyLoader LazyLoader { get; set; }

        public BaseEntity()
        {
        }

        public BaseEntity(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
    }
}