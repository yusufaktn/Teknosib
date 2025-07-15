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
    public class LegalEntityConfigration : IEntityTypeConfiguration<LegalEntity>
    {
        public void Configure(EntityTypeBuilder<LegalEntity> builder)
        {

            builder.ToTable("Tbl_LegalEntity");

            builder.HasKey(l => l.Id);
            builder.Property(l => l.AddressId).IsRequired();


            builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
            builder.Property(l => l.PhoneNumber).IsRequired().HasMaxLength(14);
            builder.Property(l => l.Email).IsRequired();
            builder.Property(l => l.WebSite);
            builder.Property(l => l.Logo);
            builder.Property(l => l.AverageRating);
            builder.Property(l => l.TotalReviews);
            builder.Property(l => l.CompletedProjects);


            builder.HasOne(l => l.Address)
                .WithOne()
                .HasForeignKey<LegalEntity>(l => l.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.AppUsers)
                .WithOne(l => l.LegalEntity)
                .HasForeignKey(l => l.LegalEntityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.OwnedProblems)
                .WithOne(l => l.OwnerLegalEntity)
                .HasForeignKey(l => l.OwnerLegalEntityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.SubmittedProposals)
               .WithOne(l => l.ProviderLegalEntity)
               .HasForeignKey(l => l.ProviderLegalEntityId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.PublishedSupportCalls)
               .WithOne(l => l.PublisherLegalEntity)
               .HasForeignKey(l => l.PublisherLegalEntityId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.ClientProjects)
            .WithOne(p => p.Client)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.ProviderProjects)
                .WithOne(p => p.Provider)
                .HasForeignKey(p => p.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.FunderProjects)
                .WithOne(p => p.Funder)
                .HasForeignKey(p => p.FunderId)
                .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
