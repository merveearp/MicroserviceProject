using ECommerce.OrderApplication.Interfaces;
using ECommerce.OrderPersistance.Concrete;
using ECommerce.OrderPersistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.OrderPersistance.Extensions
{
    public static class PersistanceRegistrations
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
