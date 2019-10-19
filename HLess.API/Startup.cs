using HLess.API.DI;
using HLess.API.ErrorHandling;
using HLess.API.Identity;
using HLess.API.Swagger;
using HLess.Data;
using HLess.Models.Entities;
using IdentityServer4.AspNetIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace HLess
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterServices(this.configuration);

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options => options.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<HLessDataContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddJwtBearerClientAuthentication()
                .AddInMemoryIdentityResources(Config.Ids)
                .AddInMemoryApiResources(Config.Apis)
                .AddInMemoryClients(Config.Clients)
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator<ApplicationUser>>()
                .AddDeveloperSigningCredential();

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.Authority = "https://localhost:44376/";
                config.Audience = "hless.api";
                config.RequireHttpsMetadata = false;
            });
            services.AddAuthorization();

            services.AddMvcCore()
                .AddApiExplorer();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "HLess API", Version = "v1" });

                var apiXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
                config.IncludeXmlComments(apiXmlPath);

                var modelsXmlFile = $"HLess.Models.xml";
                var modelsXmlPath = Path.Combine(AppContext.BaseDirectory, modelsXmlFile);
                config.IncludeXmlComments(modelsXmlPath);

                config.OperationFilter<AuthorizeOperationFilter>();

                config.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Password = new OpenApiOAuthFlow()
                        {
                            TokenUrl = new Uri("/connect/token", UriKind.Relative),
                            RefreshUrl = new Uri("/connect/token", UriKind.Relative)
                        }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HLessDataContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                context.Database.Migrate();
            }

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "HLess API V1");
            });

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
