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
    public class SolutionProviderBaseConfigration : IEntityTypeConfiguration<LegalEntity>
    {
        public void Configure(EntityTypeBuilder<LegalEntity> builder)
        {


            builder.ToTable("Tbl_SolutionProviderBase");

            builder.Property(s=>s.ContentEmail).IsRequired(false);
            builder.Property(s => s.ExpertiseAreas).IsRequired().HasMaxLength(200);
            builder.Property(s => s.Phone).IsRequired().HasMaxLength(14);


        }
    }
}
