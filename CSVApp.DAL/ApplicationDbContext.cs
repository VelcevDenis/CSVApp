using CSVApp.Contract.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSVApp.DAL {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions options) : base(options) {

        }

        public DbSet<ApplicationUser> AplicationUsers { get; set; }
        public DbSet<CSVSale> CSVSales { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SalesChannel> SalesChannels { get; set; }
    }
}
