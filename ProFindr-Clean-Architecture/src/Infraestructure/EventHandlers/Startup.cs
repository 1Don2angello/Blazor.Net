using System.Reflection;
//using MediatR.Extensions.DependencyInjection; // Asegúrate de agregar esta referencia

namespace Infraestructure.EventHandlers
{
    public static class Startup
    {
        public static IServiceCollection AddEventHandlers(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Pasar la instancia de services a RegisterServicesFromAssembly
            services.AddMediatR(assembly);

            return services;
        }
    }
}
