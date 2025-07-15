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
    public class InstitutionRepository : GenericRepository<Institution>, I_InstitutionRepository
    {
        public InstitutionRepository(MyContext context) : base(context)
        {
        }
    }
}
