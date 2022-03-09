using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.FileServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFileServices(this IServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();
            return services;
        }
    }
}