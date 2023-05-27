using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NOMRM5V\\SQLEXPRESS;initial catalog=DbKarma;integrated security=true");
        }
        public DbSet<Header> Headers { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ShoeBrand> ShoeBrands { get; set; }
        public DbSet<ShoeCategory> ShoeCategories { get; set; }
        public DbSet<ShoeColor> ShoeColors { get; set; }
        public DbSet<ShoeDiscount> ShoeDiscounts { get; set; }
        public DbSet<ShoePrice> ShoePrices { get; set; }
    }
}
