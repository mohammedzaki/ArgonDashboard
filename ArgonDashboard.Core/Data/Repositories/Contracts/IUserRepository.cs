using ArgonDashboard.Core.Data.Entities;
using ArgonDashboard.Core.Patterns.Repositroy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArgonDashboard.Core.Data.Repositories.Contracts
{
    public interface IUserRepository : IRepository<User, long>
    {
        public Task<User> FindByUsernamePasswordAsync(string username, string password);

        public UserManager<User> GetUserManager();

        public SignInManager<User> GetSignInManager();
    }
}
