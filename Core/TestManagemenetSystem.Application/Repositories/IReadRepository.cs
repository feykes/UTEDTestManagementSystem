using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(Guid id);
    }
}
