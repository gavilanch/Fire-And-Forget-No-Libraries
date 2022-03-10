using FireAndForgetDemoENG.Entities;
using Microsoft.EntityFrameworkCore;

namespace FireAndForgetDemoENG
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People => Set<Person>();
        public DbSet<Log> Logs => Set<Log>();
    }
}
