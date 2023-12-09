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
    public class TasteShoeConfiguration : IEntityTypeConfiguration<TasteShoe>
    {
        public void Configure(EntityTypeBuilder<TasteShoe> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new
            {
                x.AppUserId,
                x.ShoeId
            });
        }
    }
}
