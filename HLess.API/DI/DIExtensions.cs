using HLess.Data;
using HLess.Data.Repository;
using HLess.Data.Repository.Base;
using HLess.Data.Repository.Interfaces;
using HLess.Logic.Facades;
using HLess.Logic.Facades.Interfaces;
using HLess.Logic.Services;
using HLess.Logic.Services.Interfaces;
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

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IContentTypeRepository, ContentTypeRepository>();
            
            services.AddScoped<IContentTypeService, ContentTypeService>();

            services.AddScoped<IContentTypeFacade, ContentTypeFacade>();

            return services;
        }
    }
}
