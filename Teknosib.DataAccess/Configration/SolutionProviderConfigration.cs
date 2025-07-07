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
    public class SolutionProviderConfigration : IEntityTypeConfiguration<SolutionProviderBase>
    {
        public void Configure(EntityTypeBuilder<SolutionProviderBase> builder)
        {
            builder.ToTable("Tbl_SolutionProvider");

            builder.HasKey(s=>s.SolutionProviderId);
            builder.Property(s => s.AppUserId).IsRequired();
            builder.Property(s => s.FullName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.ExpertiseAreas).IsRequired().HasMaxLength(100);
            builder.Property(s => s.ExperienceYear).IsRequired();
            builder.Property(s => s.PortfolioUrl);

            builder.Property(s => s.TaxNumber);
            builder.Property(s => s.Description);
            builder.Property(s => s.WebSite);
            builder.Property(s => s.Address);


            builder.HasOne(s => s.AppUser)
                .WithOne(s => s.SolutionProvider)
                .HasForeignKey<SolutionProviderBase>(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Proposal)
                .WithOne(s => s.SolutionProvider)
                .HasForeignKey(s => s.SolutionProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Project)
                .WithOne(s => s.SolutionProvider)
                .HasForeignKey(s => s.SolutionProviderId)
                .OnDelete(DeleteBehavior.Restrict);





        }
    }
}
