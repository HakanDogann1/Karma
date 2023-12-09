using Karma.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DataAccessLayer.Configurations
{
    public class NumberConfiguration : IEntityTypeConfiguration<Number>
    {
        public void Configure(EntityTypeBuilder<Number> builder)
        {
            builder.Property(x => x.Num).IsRequired();
            builder.HasKey(x => x.Id);
        }
    }
}
