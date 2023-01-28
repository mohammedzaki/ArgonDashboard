using System;
using ArgonDashboard.Core.Data.Entities;
using ArgonDashboard.Core.Patterns.Generices;
using ArgonDashboard.Core.Patterns.Repositroy;

namespace ArgonDashboard.Web.Controllers
{
    public class DepartmentsController : BaseAPIRepoController<Department, long>
    {
        public DepartmentsController(IRepository<Department, long> repository)
            : base(repository)
        {
        }
    }
}
