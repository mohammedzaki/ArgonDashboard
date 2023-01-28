using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ArgonDashboard.Core.Patterns.Repositroy;

namespace ArgonDashboard.Core.Data.Entities 
{
    [Table("users")]
    [Index(nameof(Email), Name = "users_email_unique", IsUnique = true)]
    [Index(nameof(UserName), Name = "users_username_unique", IsUnique = true)]
    public partial class User : IdentityUser<long>, IEntity<long>
    {
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
