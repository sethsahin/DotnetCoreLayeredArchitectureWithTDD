using CoreWebApi.Infrastructure.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
             {
                 base.OnModelCreating(builder);
                 // Customize the ASP.NET Core Identity model and override the defaults if needed.
                 // For example, you can rename the ASP.NET Core Identity table names and more.
                 // Add your customizations after calling base.OnModelCreating(builder);
             }
         }
}