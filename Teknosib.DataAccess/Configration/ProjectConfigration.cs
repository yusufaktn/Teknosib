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
            builder.Property(p => p.ClientId).IsRequired();
            builder.Property(p => p.ProviderId).IsRequired();
            builder.Property(p => p.FunderId);



            builder.Property(p => p.ProjectStatus);
            builder.Property(p => p.ProjectName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ProjectDescription).IsRequired().HasMaxLength(300);
            builder.Property(p => p.StartDate);
            builder.Property(p => p.ComplatedDate);
            builder.Property(p => p.FinalBudget).HasColumnType("decimal(18,2)");




            builder.HasOne(p => p.Problem)
                  .WithOne(p => p.Project)
                  .HasForeignKey<Project>(p => p.ProblemId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(p=>p.Client)
                .WithMany(p=>p.ClientProjects)
                .HasForeignKey(p=>p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p=>p.Provider)
                .WithMany(p=>p.ProviderProjects)
                .HasForeignKey(p=>p.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p=>p.Funder)
                .WithMany(p=>p.FunderProjects)
                .HasForeignKey(p=>p.FunderId)
                .OnDelete(DeleteBehavior.Restrict);

                









        }
    }
}
