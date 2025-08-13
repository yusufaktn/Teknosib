using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models;
using Teknosib.Entity.Models.Enums;

namespace Teknosib.DataAccess.Repository.Interface
{
    public interface ICompanyRepository:IGenericRepository<Company>
    {
        Task<Company> UpdateApproveStatus(Guid id ,ApproveStatus status);
    }
}
