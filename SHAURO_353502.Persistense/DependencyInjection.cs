using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHAURO_353502.Persistense.Data;
using SHAURO_353502.Persistense.Repositories;

namespace SHAURO_353502.Persistense
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            return services;
        }
        public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions options)
        {
            services.AddPersistence()
                    .AddSingleton<AppDbContext>(
                    new AppDbContext((DbContextOptions<AppDbContext>)options));
            return services;
        }
    }

}
