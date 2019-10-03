using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace ViajaNet.Web.Api.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
                    options.AddPolicy("CorsPolicy", builder =>
                         builder.AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowAnyOrigin()
                                .AllowCredentials()
                                .Build())
            );

            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "ViajaNet Api", Version = "v1" });
                options.DescribeAllEnumsAsStrings();
                options.DescribeAllParametersInCamelCase();
            });

            return services;
        }
    }
}
