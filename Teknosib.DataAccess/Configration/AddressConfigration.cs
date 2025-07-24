using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Entity.Models;

namespace Teknosib.DataAccess.Configration
{
    public class AddressConfigration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Tbl_Address");
            builder.HasKey(x => x.AddressId);

            builder.Property(x => x.Country).IsRequired().HasMaxLength(300);
            builder.Property(x => x.City).IsRequired().HasMaxLength(300);
            builder.Property(x => x.District).HasMaxLength(50);
            builder.Property(x => x.AddressLine).HasMaxLength(350);
            builder.Property(x => x.PostalCode).HasMaxLength(50);

            



        }
    }
}
