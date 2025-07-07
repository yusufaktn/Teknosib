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
    public class IndividualProviderConfigration : IEntityTypeConfiguration<IndividualProvider>
    {
        public void Configure(EntityTypeBuilder<IndividualProvider> builder)
        {
            builder.ToTable("Tbl_IndividualProvider");
            

            builder.Property(i => i.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(i=> i.LastName).IsRequired().HasMaxLength(150);
            builder.Property(i=> i.TCKN).IsRequired().HasMaxLength(11);
            builder.Property(i=> i.Biography).IsRequired().HasMaxLength(500);
            builder.Property(i=> i.Education).IsRequired(false);
            builder.Property(i=> i.Certifications).IsRequired();
            builder.Property(i=> i.PortfolioUrl).IsRequired(false);
            builder.Property(i=> i.LinkedInUrl).IsRequired(false);
            builder.Property(i=> i.GitHubUrl).IsRequired(false);


            builder.HasOne(i=>i.AppUser)
                .WithOne(i=>i.IndividualProvider)
                .HasForeignKey<IndividualProvider>(i=>i.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
