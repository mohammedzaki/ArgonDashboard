using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArgonDashboard.Core.Patterns.Generices
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController<TDbContext> : ControllerBase
        where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;

        public BaseAPIController(TDbContext context)
        {
            _dbContext = context;
        }
    }
}
