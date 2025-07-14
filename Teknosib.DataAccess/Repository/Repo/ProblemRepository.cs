using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.DataAccess.EntitiyFramework;
using Teknosib.DataAccess.Repository.Interface;
using Teknosib.Entity.Models;

namespace Teknosib.DataAccess.Repository.Repo
{
    public class ProblemRepository : GenericRepository<Problem>, IProblemRepository
    {
        public ProblemRepository(MyContext context) : base(context)
        {
            
        }

        public async Task<List<Problem>> GetProblemByCategoryIdAsync(Guid categoryid)
        {
            
            var problem  = await _dbSet.Where(x=>x.CategoryId==categoryid).Where(x=>x.Status==true)
                .Include(x=>x.Category)
                .Include(x=>x.Company).ToListAsync();
            return problem;           
        }

        public Task<List<Problem>> GetProblemWithDetail()
        {
            var problem = _dbSet.Where(x=>x.Status==true).Include(x=>x.Category).Include(x=>x.Company).ToListAsync() ;
            return problem;
        }
    }
}
