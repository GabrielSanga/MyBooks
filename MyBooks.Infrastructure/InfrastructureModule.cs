using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBooks.Core.Repositories;
using MyBooks.Infrastructure.Persistence;
using MyBooks.Infrastructure.Persistence.Repositories;
using System.Net.NetworkInformation;

namespace MyBooks.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddData(configuration);
            services.AddRepostory();

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connetionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MyBooksDBContext>(o => o.UseSqlServer(connetionString));

            return services;
        }

        private static IServiceCollection AddRepostory(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
