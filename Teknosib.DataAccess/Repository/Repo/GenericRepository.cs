using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teknosib.DataAccess.EntitiyFramework;
using Teknosib.DataAccess.Repository.Interface;
using Teknosib.Entity.Models;

namespace Teknosib.DataAccess.Repository.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntitiy
    {
        private readonly MyContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }



        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public async Task SoftDeleteAsync(T entity)
        {

            entity.Status = false;
            entity.UpdatedDate = DateTime.Now;
            _dbSet.Update(entity);

        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {

            return await _dbSet.FirstOrDefaultAsync(filter);

        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);      
           
        }

        public async Task<List<T>> GetListAllAsync()
        {
            return await _dbSet.Where(x => x.Status == true).ToListAsync();
        }


        public async Task<List<T>> GetListIncludingStatusFalse()
        {
            return await _dbSet.ToListAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            entity.UpdatedDate = DateTime.Now;

        }

        public async Task HardDeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
