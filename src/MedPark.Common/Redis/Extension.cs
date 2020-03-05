using MedPark.Common.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedPark.Common.Redis
{
    public static class Extension
    {
        private static readonly string SectionName = "redis";

        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisOptions();
            configuration.GetSection(SectionName).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled)
            {
                return services;
            }

            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisCacheSettings.ConnectionString));
            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSettings.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();

            return services;
        }
    }
}
