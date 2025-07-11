using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models;

namespace Teknosib.DataAccess.Repository.Interface
{
    public interface IGenericRepository<T> where T : BaseEntitiy
    {
        Task<List<T>> GetListAllAsync();
        Task<List<T>> GetListIncludingStatusFalse();

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync (T entity);
        Task UpdateAsync (T entity);
        Task SoftDeleteAsync (T entity);
        Task HardDeleteAsync (T entity);


    }
}
