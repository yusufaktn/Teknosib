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
        Task<List<T>> GetListAll(bool includeDeleted = false);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetById(Guid id);
        Task Add (T entity);
        Task Update (T entity);
        Task Delete (T entity);


    }
}
