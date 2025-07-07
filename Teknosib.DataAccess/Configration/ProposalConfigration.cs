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
    public class ProposalConfigration : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder.ToTable("Tbl_Proposal");

            builder.HasKey(p => p.ProposalId);
            builder.Property(p => p.ProblemId).IsRequired();
            builder.Property(p => p.SolutionProviderId).IsRequired();
            builder.Property(p => p.OfferDetails).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Currency).IsRequired();
            builder.Property(p => p.ProposalStatus);


            builder.HasOne(p => p.Problem)
                .WithMany(p => p.Proposal)
                .HasForeignKey(p => p.ProblemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.SolutionProviderBase)
                .WithMany(p => p.Proposal)
                .HasForeignKey(p => p.SolutionProviderId)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
