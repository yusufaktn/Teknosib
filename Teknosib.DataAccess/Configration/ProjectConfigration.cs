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
    public class ProjectConfigration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Tbl_Project");

            builder.HasKey(p => p.ProjectId);
            builder.Property(p => p.ProblemId).IsRequired();
            builder.Property(p => p.KosgebSupportId);
            builder.Property(p => p.SolutionProviderId).IsRequired();
            builder.Property(p => p.ProjectStatus);
            builder.Property(p => p.ProjectName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ProjectDescription).IsRequired().HasMaxLength(300);
            

            

            builder.HasOne(p => p.Problem)
                .WithOne(p => p.Project)
                .HasForeignKey<Project>(p => p.ProblemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.SolutionProviderBase)
                .WithMany(p => p.Project)
                .HasForeignKey(p => p.SolutionProviderId)
                .OnDelete(DeleteBehavior.Restrict);


            






        }
    }
}
