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
            builder.HasIndex(x=>x.Email).IsUnique();
            builder.Property(x=>x.PasswordHash).IsRequired();
            builder.Property(x=>x.PasswordSalt).IsRequired();


            //(one to one)
            builder.HasOne(x => x.Company)
                .WithOne(x => x.AppUser)
                .HasForeignKey<Company>(x => x.AppUserId);

        }
    }
}
