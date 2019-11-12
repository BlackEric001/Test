using Infrastructure.RemoteServices;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRefitRemoteCalculationService(this IServiceCollection services)
        {
            services.AddScoped(provider => RefitServiceProvider.GetRemoteCalculationService<IRemoteCalculationService>(provider));
            return services;
        }
    }
}
