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
    internal class ProblemRepository : GenericRepository<Problem>, IProblemRepository
    {
        public ProblemRepository(MyContext context) : base(context)
        {
        }
    }
}
