using Microsoft.EntityFrameworkCore;
using WebAPIProject.Server.Models;

namespace WebAPIProject.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
