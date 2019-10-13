using HLess.Data;
using HLess.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HLess.API.DI
{
    /// <summary>
    /// Extension methods for dependency injection
    /// </summary>
    public static class DIExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HLessDataContext>(options =>
            {
                options.UseSqlServer(configuration[ConfigKeys.CONNECTION_STRING]);
            });

            return services;
        }
    }
}
