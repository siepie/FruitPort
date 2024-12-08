using FruitPort.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FruitPort.Api;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection
            .AddDbContextFactory<FruitContext>(options => options.UseSqlServer(configuration.GetConnectionString("Fruitigo")));
    }
}
