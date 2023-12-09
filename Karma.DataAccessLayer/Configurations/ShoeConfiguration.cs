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
    public class ShoeConfiguration : IEntityTypeConfiguration<Shoe>
    {
        public void Configure(EntityTypeBuilder<Shoe> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new
            {
                x.BrandId,
                x.ColorId,
                x.CategoryId,
                x.NumberId
            });

            builder.Property(x => x.Title).IsRequired().HasMaxLength(400);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(400);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Width).IsRequired();
            builder.Property(x => x.Height).IsRequired();
            builder.Property(x => x.Depth).IsRequired();
        }
    }
}
