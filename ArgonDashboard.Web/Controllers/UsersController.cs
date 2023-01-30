using ArgonDashboard.Core.Data.Entities;
using ArgonDashboard.Core.Data.Repositories.Contracts;
using ArgonDashboard.Core.Patterns.Generices;

namespace ArgonDashboard.Web.Controllers
{
    public class UsersController : BaseAPIRepoController<User, long>
    {
        public UsersController(IUserRepository repository)
            : base(repository)
        {
        }
    }
}
