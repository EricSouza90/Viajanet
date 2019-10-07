using Couchbase.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Swashbuckle.AspNetCore.Swagger;
using System;
using ViajaNet.Background.Jobs;
using ViajaNet.TrackingData.Common;
using ViajaNet.TrackingData.Domain.Repository;
using ViajaNet.TrackingData.Infrastructure.Couchbase;
using ViajaNet.TrackingData.Infrastructure.Queue;
using ViajaNet.TrackingData.Infrastructure.Queue.Helper;
using ViajaNet.TrackingData.Infrastructure.Repository;
using ViajaNet.Web.Api.HostedService;

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
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("ViajaNet.TrackingData");
            services.AddMediatR(assembly);
            return services;
        }
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQConfiguration>(configuration.GetSection("RabbitMQConfiguration"));
            services.Configure<CouchbaseConfiguration>(configuration.GetSection("CouchbaseConfiguration"));
            services.AddScoped<IQueueRepository, QueueRepository>();
            services.AddScoped<IQueue, RabbitMQHelper>();
            services.AddScoped<ICouchbaseConnection, CouchbaseConnection>();
            services.AddScoped<IDataTrackingRepository, DataTrackingRepository>();

            return services;
        }
        public static IServiceCollection AddJobs(this IServiceCollection services, IConfiguration configuration)
        {
            var jobsConfig = configuration.GetSection("JobsConfig").Get<JobsConfig>();

            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<QuartzJobRunner>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddScoped<ProcessQueueMessageJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(ProcessQueueMessageJob),
                cronExpression: jobsConfig.ProcessQueueMessageJobConfig.CronExpression));

            return services;
        }
        public static IServiceCollection ConfigureDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCouchbase(configuration.GetSection("CouchbaseConfig"));
            return services;
        }
    }
}
