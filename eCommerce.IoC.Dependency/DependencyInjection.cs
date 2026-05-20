using eCommerce.Core.Entities.RepositoryContracts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}
