using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyBooks.Core.Authenticate;
using MyBooks.Core.Repositories;
using MyBooks.Core.Services;
using MyBooks.Infrastructure.Authenticate;
using MyBooks.Infrastructure.ExternalService.GoogleBooksAPI;
using MyBooks.Infrastructure.Persistence;
using MyBooks.Infrastructure.Persistence.Repositories;

namespace MyBooks.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddData(configuration);
            services.AddRepostory();
            services.AddServicesExternal(configuration);
            services.AddAuthorization(configuration);

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

        private static IServiceCollection AddServicesExternal(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GoogleBooksOptions>(configuration.GetSection("GoogleBooksAPI"));

            services.AddHttpClient<IBookService, GoogleBookService>((serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<GoogleBooksOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseUrl);
            });

            return services;
        }

        private static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(o =>
                        {
                            o.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = configuration["Jwt:Issuer"],
                                ValidAudience = configuration["Jwt:Audience"],
                                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? ""))
                            };
                        });

            return services;
        }
    }
}
