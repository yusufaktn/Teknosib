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
    public class AppUserConfigration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.ToTable("Tbl_AppUser");


            builder.HasKey(x=>x.AppUserId);
            builder.Property(x=>x.LegalEntityId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(100);

            builder.HasIndex(x=>x.Email).IsUnique();
            builder.Property(x=>x.PasswordHash).IsRequired();
            builder.Property(x=>x.PasswordSalt).IsRequired();


            
            builder.HasOne(x => x.LegalEntity)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.LegalEntityId);

        }
    }
}
