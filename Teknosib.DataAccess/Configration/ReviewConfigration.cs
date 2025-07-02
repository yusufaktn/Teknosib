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
    public class ReviewConfigration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Tbl_Review");

            builder.HasKey(r => r.ReviewId);
            builder.Property(r => r.ReviewerId).IsRequired();
            builder.Property(r => r.RevieweeId).IsRequired();
            builder.Property(r => r.ProjectId).IsRequired();
            builder.Property(r => r.Rating).IsRequired();
            builder.Property(r => r.Comment).IsRequired().HasMaxLength(200);

            builder.HasOne(r => r.Reviewee)
                .WithMany(r => r.ReviewsRecevid)
                .HasForeignKey(r => r.RevieweeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Reviewer)
                .WithMany(r => r.ReviewWritten)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Project)
                .WithOne(r => r.Review)
                .HasForeignKey<Review>(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
