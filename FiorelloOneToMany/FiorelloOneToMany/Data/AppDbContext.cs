using FiorelloOneToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace FiorelloOneToMany.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Product> Products { get; set; }
    }

}
