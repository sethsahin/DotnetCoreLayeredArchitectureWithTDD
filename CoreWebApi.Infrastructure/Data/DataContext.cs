using CoreWebApi.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}