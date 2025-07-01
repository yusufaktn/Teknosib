using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models;

namespace Teknosib.DataAccess.EntitiyFramework
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
          
        }

        public DbSet<AppUser> AppUsers{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company>Companies{ get; set; }
        public DbSet<KosgebSupport>KosgebSupports{ get; set; }
        public DbSet<Problems> Problems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SolutionProvider> SolutionProviders { get; set; }
        


    }
}
