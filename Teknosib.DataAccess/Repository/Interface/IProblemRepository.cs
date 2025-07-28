using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models;

namespace Teknosib.DataAccess.Repository.Interface
{
    public interface IProblemRepository:IGenericRepository<Problem>
    {
        Task<List<Problem>> GetProblemByCategoryIdAsync(Guid categoryid);
        Task<List<Problem>> GetProblemByCompanyIdAsync(Guid companyid);
        Task<List<Problem>> GetProblemByInstitutionIdAsync(Guid institutionid);
        Task<List<Problem>> GetProblemWithDetail();
    }
}
