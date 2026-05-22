using eCommerce.Core.Entities.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Infrastructure.DbContexts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace eCommerce.IoC.Dependency;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add all projects services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    /// 

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var serviceCollection = services.AddApi();
        serviceCollection = serviceCollection.AddInfrastructure();
        serviceCollection = serviceCollection.AddCore();
        return serviceCollection;
    }

    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<DapperDbContext>();

        services.AddDbContext<EfDbContext>((sp, options) =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
        });

        return services;
    }

    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
