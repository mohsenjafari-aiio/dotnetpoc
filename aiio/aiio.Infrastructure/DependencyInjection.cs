using aiio.Domain.Interfaces;
using aiio.Domain.Models.Processes;
using aiio.Domain.Models.Students;
using aiio.Infrastructure.Persistence;
using aiio.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace aiio.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AiioDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IProcessRepository, ProcessRepository>();            

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static void ApplyMigrations(this IHost app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AiioDbContext>();
            db.Database.Migrate();
        }
    }
}
