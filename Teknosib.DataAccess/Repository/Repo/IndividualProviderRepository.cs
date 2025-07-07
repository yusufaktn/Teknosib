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
    public class IndividualProviderRepository : GenericRepository<IndividualProvider>, IindividualProviderRepository
    {
        public IndividualProviderRepository(MyContext context) : base(context)
        {
        }
    }
}
