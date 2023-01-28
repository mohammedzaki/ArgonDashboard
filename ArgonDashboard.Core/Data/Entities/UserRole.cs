using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace ArgonDashboard.Core.Data.Entities
{
    [Table("user_role")]
    public partial class UserRole : IdentityUserRole<long>
    {

    }
}
