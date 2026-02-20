using Microsoft.Extensions.DependencyInjection;
using MyBooks.Application.Commands.CommandsUsuario;

namespace MyBooks.Application
{
    public static class ApplicationModule
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR();

            return services;
        }

        private static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<InserirUsuarioCommand>());

            return services;
        }

    }
}
