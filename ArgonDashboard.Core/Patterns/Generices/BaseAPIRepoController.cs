using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArgonDashboard.Core.Patterns.Repositroy;

namespace ArgonDashboard.Core.Patterns.Generices
{
    public class BaseAPIRepoController<TEntity, TKey> : GenericAPIRepoController<IRepository<TEntity, TKey>, TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct,
          IComparable,
          IComparable<TKey>,
          IConvertible,
          IEquatable<TKey>,
          IFormattable
    {
        public BaseAPIRepoController(IRepository<TEntity, TKey> repository)
            : base(repository)
        {
        }
    }
}
