using Karma.DataAccessLayer.Configurations;
using Karma.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DataAccessLayer.Context
{
    public class KarmaDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public KarmaDbContext(DbContextOptions<KarmaDbContext> options):base(options)
        {
            
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.ApplyConfiguration(new BasketConfiguration());
        //    builder.ApplyConfiguration(new BrandConfiguration());
        //    builder.ApplyConfiguration(new CategoryConfiguration());
        //    builder.ApplyConfiguration(new ColorConfiguration());
        //    builder.ApplyConfiguration(new CommentConfiguration());
        //    builder.ApplyConfiguration(new NumberConfiguration());
        //    builder.ApplyConfiguration(new ShoeConfiguration());
        //    builder.ApplyConfiguration(new TasteShoeConfiguration());
        //    builder.ApplyConfiguration(new AppUserConfiguration());
        //}

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<NewCollection> NewCollections { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Number> Numbers { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<TasteShoe> tasteShoes { get; set; }
    }
}
