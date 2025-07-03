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
        private readonly DbSet<T> _dbSet;
        public GenericRepository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }



        public async Task Add(T entity)
        {
           await _dbSet.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task Delete(T entity)
        {

            entity.Status = false;
            entity.UpdatedDate = DateTime.Now;
            _dbSet.Update(entity);
           await _context.SaveChangesAsync();

        }

        public Task<List<T>> GetAllTrue(Expression<Func<T, bool>> expression)
        {
            var query = _dbSet.Where(x => x.Status == true).ToListAsync();
            return query;
        }

        public async Task<T> GetById(Guid id)
        {
            var entity =  await _dbSet.FindAsync(id);
            if(entity == null && entity.Status==false)
            {
                return null;
            }
            return entity;
        }

        public async Task<List<T>> GetListAll()
        {
          return  await _dbSet.ToListAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            entity.UpdatedDate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
