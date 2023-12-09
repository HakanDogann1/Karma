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
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new
            {
                x.AppUserId,
                x.ShoeId
            });
            builder.Property(x=>x.Piece).IsRequired();
            builder.Property(x=>x.Status).IsRequired();
        }
    }
}
