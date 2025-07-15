using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Teknosib.DataAccess.Configration;
using Teknosib.Entity.Models;

namespace Teknosib.DataAccess.EntitiyFramework
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
          
        }

        public DbSet<AppUser> AppUsers{ get; set; }
        public DbSet<Address> Addresses{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company>Companies{ get; set; }
        public DbSet<SupportCall>SupportCalls{ get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Institution> Institutions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            
        }



    }
}
