using aiio.Domain.Models.Departments;
using aiio.Domain.Models.Locations;
using aiio.Domain.Models.Processes;
using aiio.Domain.Models.Resources;
using aiio.Domain.Models.Roles;
using aiio.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace aiio.Infrastructure.Persistence
{
    public class AiioDbContext : DbContext
    {
        public AiioDbContext(DbContextOptions<AiioDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Resource> Resources => Set<Resource>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Process> Processes => Set<Process>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AiioDbContext).Assembly);
        }
    }
}
