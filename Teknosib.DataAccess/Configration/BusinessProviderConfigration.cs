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
    public class BusinessProviderConfigration : IEntityTypeConfiguration<BusinessProvider>
    {
        public void Configure(EntityTypeBuilder<BusinessProvider> builder)
        {
            builder.ToTable("Tbl_BusinessProvider");
            
            
            builder.Property(bp=>bp.CompanyName).IsRequired();
            builder.Property(bp=>bp.TaxNumber).IsRequired();
            builder.Property(bp=>bp.OfficialAddress).IsRequired();
            builder.Property(bp => bp.PhysicalAddress);
            builder.Property(bp => bp.WebSite);
            builder.Property(bp => bp.TeamSize);
            builder.Property(bp => bp.PortfolioUrl);



            builder.HasOne(bp=>bp.AppUser)
                .WithOne(bp=>bp.BusinessProvider)
                .HasForeignKey<BusinessProvider>(bp=>bp.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
