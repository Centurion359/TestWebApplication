using Microsoft.EntityFrameworkCore;
using TestWebApplication.Models;

namespace TestWebApplication.AppDbContext
{
    public class TaskDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TaskDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<TestWebApplication.Models.Task> tasks => Set<TestWebApplication.Models.Task>();

    }
}
