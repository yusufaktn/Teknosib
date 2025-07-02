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
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.ToTable("Tbl_Category");

            builder.HasKey(x=>x.CategoryId);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x=>x.Description).HasMaxLength(150);


            builder.HasMany(x=>x.Problem)
                .WithOne(x=>x.Category)
                .HasForeignKey(x=>x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
