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
            builder.Property(p => p.OwnerLegalEntityId).IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(250);
            
            

            builder.HasOne(p => p.Category)
                .WithMany(p => p.Problem)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.OwnerLegalEntity)
                .WithMany(p => p.OwnedProblems)
                .HasForeignKey(p => p.OwnerLegalEntityId)
                .OnDelete(DeleteBehavior.Restrict);
         
            builder.HasMany(p => p.Proposal)
                .WithOne(p => p.Problem)
                .HasForeignKey(p => p.ProblemId)
                .OnDelete(DeleteBehavior.Restrict);

            
            


        }

    }
}
