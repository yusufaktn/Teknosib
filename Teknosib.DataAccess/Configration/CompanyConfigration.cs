using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models;

namespace Teknosib.DataAccess.Configration
{
    public class CompanyConfigration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Tbl_Company");

           

            builder.Property(c=>c.TaxNumber).IsRequired().HasMaxLength(10);
            builder.Property(c=>c.Description).HasMaxLength(250);
            builder.Property(c => c.Industry).HasMaxLength(100);
            builder.Property(c => c.EmployeeCount).HasDefaultValue(0);

            
        }
    }
}
