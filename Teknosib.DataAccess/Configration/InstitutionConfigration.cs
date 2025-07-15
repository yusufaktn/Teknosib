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
    public class InstitutionConfigration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {

            builder.ToTable("Tbl_Institution");
            

            builder.Property(i=>i.Type).IsRequired();
            builder.Property(i => i.InstitutionCode);
            builder.Property(i => i.OfficialTitle).HasMaxLength(100);
            builder.Property(i => i.AuthorityName).HasMaxLength(100);
            builder.Property(i => i.InstitutionCode).HasMaxLength(100);

        }
    }
}
