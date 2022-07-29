using CircleAndComments.Models;
using Microsoft.EntityFrameworkCore;

namespace CircleAndComments.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
