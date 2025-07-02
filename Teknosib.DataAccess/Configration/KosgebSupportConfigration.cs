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
    public class KosgebSupportConfigration : IEntityTypeConfiguration<KosgebSupport>
    {
        public void Configure(EntityTypeBuilder<KosgebSupport> builder)
        {
            builder.ToTable("Tbl_KosgebSupport");

            builder.HasKey(k=>k.KosgebSupportId);
            builder.Property(k => k.Name).IsRequired().HasMaxLength(100);
            builder.Property(k => k.Description).IsRequired().HasMaxLength(500);
            builder.Property(k => k.MaxSupportAmount).IsRequired();



            builder.HasOne(k => k.Project)
                .WithOne(p => p.KosgebSupport)
                .HasForeignKey<Project>(p => p.KosgebSupportId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);



        }
    }
}
