using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Click360.API.Config
{
    /// <summary>
    /// To configure <see cref="SwaggerGenOptions"/> TOption type.
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        /// <summary>
        /// Configure versioned API documentation.
        /// </summary>
        /// <param name="options">The Swagger options.</param>
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Click360 API",
                        Version = "v1",
                        Description = "The Click360 API Solution.",
                        Contact = new OpenApiContact
                        {
                            Email = "midhukkl@gmail.com",
                            Name = "Click360 Engineering"
                        }
                    });
            options.CustomSchemaIds(x => x.FullName);
            options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            options.IncludeXmlComments($"{Program.WorkingDirectory}/Click360.API.xml", true);
            options.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Authorization Key: bearer token",
                    Scheme = "Bearer",
                    BearerFormat = "Bearer {token}"
                });
            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement()
                {
                    {
                       new OpenApiSecurityScheme
                       {
                           Reference = new OpenApiReference
                           {
                               Type = ReferenceType.SecurityScheme,
                               Id = "Bearer"
                           }
                       },
                       new List<string>()
                    }
                });
        }
    }
}
