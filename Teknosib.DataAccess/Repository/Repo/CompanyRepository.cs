using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.DataAccess.EntitiyFramework;
using Teknosib.DataAccess.Repository.Interface;
using Teknosib.Entity.Models;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.DataAccess.Repository.Repo
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(MyContext context) : base(context)
        {
            
        }

        public async Task<Company> UpdateApproveStatus(Guid id, ApproveStatus status)
        {
            var company = await _dbSet.FirstOrDefaultAsync(x=>x.Id==id);
            if (company != null)
            {
                company.AproveStatus =status;
                company.UpdatedDate = DateTime.Now;
                return company;
            }
            return null;
        }
    }
}
