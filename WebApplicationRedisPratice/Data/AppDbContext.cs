using Microsoft.EntityFrameworkCore;
using WebApplicationRedisPratice.Model;

namespace WebApplicationRedisPratice.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
