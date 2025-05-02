using System.Reflection;
using aiio.Framework.Abstractions;
using aiio.Framework.CQRS;
using aiio.Framework.Pipeline;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace aiio.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register all MediatR handlers (command & query)
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Application.DependencyInjection).Assembly);
            });


            // Register CQRS processors (optional wrappers for ISender)
            services.AddScoped<ICommandProcessor, CommandProcessor>();
            services.AddScoped<IQueryProcessor, QueryProcessor>();

            // Register all FluentValidation validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register MediatR pipeline behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

            return services;
        }
    }
}
