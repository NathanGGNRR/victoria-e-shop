//-----------------------------------------------------------------------
// <copyright file="DependencyInjection.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Infrastructure
{
    using Application.Common.Interfaces;
    using Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using ServiceStack.Redis;

    /// <summary>
    /// The class containing all the dependency injections of the Infrastructure layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Method to set the dependency injections for the database.
        /// </summary>
        /// <param name="services">IServiceCollection object.</param>
        /// <param name="configuration">IConfiguration object.</param>
        /// <returns>Return a IServiceCollection</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDistributedCache>(p => p.GetService<IDistributedCache>());
            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<IRedisClient, RedisClient>();

            return services;
        }
    }
}