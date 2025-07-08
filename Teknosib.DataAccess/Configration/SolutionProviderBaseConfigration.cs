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
    public class SolutionProviderBaseConfigration : IEntityTypeConfiguration<SolutionProviderBase>
    {
        public void Configure(EntityTypeBuilder<SolutionProviderBase> builder)
        {


            builder.ToTable("Tbl_SolutionProviderBase");

            builder.Property(s=>s.Email).IsRequired(false);


        }
    }
}
