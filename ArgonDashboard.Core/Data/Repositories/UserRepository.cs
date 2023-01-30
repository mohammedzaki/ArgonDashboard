using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ArgonDashboard.Core.Data.Repositories.Contracts;
using ArgonDashboard.Core.Patterns.Repositroy;
using ArgonDashboard.Core.Data.Entities;
using ArgonDashboard.Helpers;
using ArgonDashboard.Core.ExceptionHandler;

namespace ArgonDashboard.Core.Data.Repositories
{
    public class UserRepository : EntityRepository<ArgonDbContext, User, long>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(
            ArgonDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ClaimsPrincipal claimsPrincipal)
            : base(context, claimsPrincipal)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public UserManager<User> GetUserManager()
        {
            return _userManager;
        }

        public SignInManager<User> GetSignInManager()
        {
            return _signInManager;
        }

        public async Task<User> FindByUsernamePasswordAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            var valid = await _signInManager.UserManager.CheckPasswordAsync(user, password);
            if (valid)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var roles = _dbContext.Roles
                    .Where(item => userRoles.Any(n => n == item.Name))
                    .Select(e => new Role { Id = e.Id, Name = e.Name, IsActive = e.IsActive, ConcurrencyStamp = null }).ToList();
                user.PasswordHash = null;
                return user;
            }
            else
            {
                return null;
            }
        }

        public override async Task<User> SaveAsync(User user)
        {
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.CreatedBy = User.GetLoggedInUserId<long>();
            user.UpdatedBy = User.GetLoggedInUserId<long>();
            using var transaction = _dbContext.Database.BeginTransaction();
            await CreateUser(user);
            await transaction.CommitAsync();
            return user;
        }

        public override async Task<User> UpdateAsync(User user)
        {
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = User.GetLoggedInUserId<long>();
            using var transaction = _dbContext.Database.BeginTransaction();
            await base.UpdateAsync(user);
            await transaction.CommitAsync();
            return user;
        }

        private async Task CreateUser(User user)
        {
            user.Id = GenerateNewID();
            var result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
            {
                var ex = new AppException("create new user validation failed");
                foreach (var item in result.Errors)
                {
                    ex.Errors.Add(item.Code, item.Description);
                }
                throw ex;
            }
        }
    }
}
