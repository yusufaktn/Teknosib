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
    public class SupportCallConfigration : IEntityTypeConfiguration<SupportCall>
    {
        public void Configure(EntityTypeBuilder<SupportCall> builder)
        {
            builder.ToTable("Tbl_SupportCall");
            builder.HasKey(s=>s.SupportCallId);

            builder.Property(s => s.PublisherLegalEntityId).IsRequired();
            builder.Property(s => s.Title).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Description).IsRequired().HasMaxLength(600);
            builder.Property(s => s.SupportAmount).IsRequired();


            builder.HasOne(s=>s.PublisherLegalEntity)
                .WithMany(s=>s.PublishedSupportCalls)
                .HasForeignKey(s=>s.PublisherLegalEntityId)
                .OnDelete(DeleteBehavior.Restrict);
                

        }
    }
}
