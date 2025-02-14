using BaseExchange.OrderGenerator.Application.Interfaces;
using BaseExchange.OrderGenerator.Domain.Interfaces;
using BaseExchange.OrderGenerator.Infrastructure.Fix;
using BaseExchange.OrderGenerator.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseExchange.OrderGenerator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseInMemoryDatabase("OrdersDb"));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddSingleton<FixApplication>();
            services.AddScoped<IFixMessageService, FixMessageService>();

            services.Configure<FixSettings>(
                configuration.GetSection("FixSettings"));

            return services;
        }
    }
}