using aiio.Domain.Models.Departments;
using aiio.Domain.Models.Locations;
using aiio.Domain.Models.Processes;
using aiio.Domain.Models.Resources;
using aiio.Domain.Models.Roles;
using aiio.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace aiio.Infrastructure.Persistence
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AiioDbContext>();            

            try
            {
                // Ensure the database is created
                await context.Database.EnsureCreatedAsync();

                var userId = Guid.Parse("ffde379a-09b5-4e99-a9a9-13805fb040e2");
                var user = await context.Users.FirstOrDefaultAsync(r => r.Id == userId);
                // Seed Users
                if (user is null)
                {
                    user = User.Create(userId, "Default User");
                    
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();                    
                }

                // Seed Locations
                if (!await context.Locations.AnyAsync())
                {
                    var location = Location.Create(Guid.NewGuid(), "Default Location", user);                    
                    context.Locations.Add(location);
                    await context.SaveChangesAsync();
                }

                // Seed Roles
                if (!await context.Roles.AnyAsync())
                {
                    var role = Role.Create(Guid.NewGuid(), "Default Role", user);                    
                    context.Roles.Add(role);
                    await context.SaveChangesAsync();                    
                }

                // Seed Resources
                if (!await context.Resources.AnyAsync())
                {
                    var resource = Resource.Create(Guid.NewGuid(), "Default Resource", user);                    
                    context.Resources.Add(resource);
                    await context.SaveChangesAsync();
                }

                // Seed Departments
                if (!await context.Departments.AnyAsync())
                {
                    var department = Department.Create(Guid.NewGuid(), "Default Department", user);                    
                    context.Departments.Add(department);
                    await context.SaveChangesAsync();
                }

                // Seed Processes
                if (!await context.Processes.AnyAsync())
                {
                    var processId = Guid.Parse("a172035c-bd81-4d3e-80be-7a9f8d58dee6");
                    var process = Process.Create(processId, "Default Process", "Default process description", user);
                    
                    context.Processes.Add(process);
                    await context.SaveChangesAsync();

                    // Add relationships
                    var department = await context.Departments.FirstAsync();
                    var role = await context.Roles.FirstAsync();
                    var resource = await context.Resources.FirstAsync();
                    var location = await context.Locations.FirstAsync();

                    process.AddDepartment(department);
                    process.AddRole(role);
                    process.AddResource(resource);
                    process.AddLocation(location);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while seeding the database.", ex);
            }
        }
    }
}
