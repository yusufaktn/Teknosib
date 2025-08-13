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
    public class InstitutionRepository : GenericRepository<Institution>, I_InstitutionRepository
    {
        public InstitutionRepository(MyContext context) : base(context)
        {
        }

        public async Task<Institution> UpdateApproveStatus(Guid id, ApproveStatus status)
        {
            var institution = await _dbSet.FindAsync(id);
            if (institution != null)
            {
                institution.AproveStatus = status;
                institution.UpdatedDate = DateTime.Now;
                return institution;
            }
            return null;
        }
    }
}
