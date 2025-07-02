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

            builder.HasKey(c => c.CompanyId);
            builder.Property(c => c.AppUserId).IsRequired();
            builder.Property(c=>c.CompanyName).IsRequired().HasMaxLength(100);
            builder.Property(c=>c.TaxNumber).IsRequired().HasMaxLength(10);
            builder.Property(c=>c.Address).IsRequired().HasMaxLength(200);
            builder.Property(c=>c.Description).HasMaxLength(250);


            builder.HasOne(c => c.AppUser)
                .WithOne(c => c.Company)
                .HasForeignKey<Company>(c => c.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c=>c.Problem)
                .WithOne(c=>c.Company)
                .HasForeignKey(c=>c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);






            
        }
    }
}
