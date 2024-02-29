using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


    namespace Infraestructure.EventHandlers
    {
        public static class Startup
        {
            public static IServiceCollection AddEventHandlers(this IServiceCollection services)
            {
                var assembly = Assembly.GetExecutingAssembly();

                services.AddMediatR(config =>
                {
                    config.RegisterServicesFromAssembly(assembly);
                });

                return services;
            }
        }
    }
