using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace HLess.API.Swagger
{
    /// <summary>
    /// Operation filter for marking authorized routes in Swagger
    /// and token integration.
    /// </summary>
    public class AuthorizeOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            bool hasAuth = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<AuthorizeAttribute>().Any();

            if (hasAuth)
            {
                operation.Responses.Add(StatusCodes.Status401Unauthorized.ToString(), new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.Add(StatusCodes.Status403Forbidden.ToString(), new OpenApiResponse { Description = "Forbidden" });

                operation.Security = new List<OpenApiSecurityRequirement> 
                {
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme 
                                {
                                     Reference = new OpenApiReference
                                     {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "oauth2"
                                     },
                                    Type = SecuritySchemeType.OAuth2
                                }, 
                            new List<string>() 
                        }
                    }
                };
            }
        }
    }
}
