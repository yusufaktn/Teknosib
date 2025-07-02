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
    public class ProblemConfigration : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder.ToTable("Tbl_Problem");
            builder.HasKey(p=>p.ProblemId);
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.CompanyId).IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(250);
            builder.Property(p => p.MinBudget).HasColumnType("decimal(18,2)");
            builder.Property(p => p.MaxBudget).HasColumnType("decimal(18,2)");
            

            builder.HasOne(p => p.Category)
                .WithMany(p => p.Problem)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Company)
                .WithMany(p => p.Problem)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(p => p.Proposal)
                .WithOne(p => p.Problem)
                .HasForeignKey(p => p.ProblemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Project)
                .WithOne(p => p.Problem)
                .HasForeignKey<Project>(p => p.ProblemId)
                .OnDelete(DeleteBehavior.Restrict);

            


        }

    }
}
