//-----------------------------------------------------------------------
// <copyright file="DependencyInjection.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Infrastructure
{
    using System;
    using Application.Common.Interfaces;
    using Application.ElasticSearch.Interfaces;
    using Infrastructure.Persistence;
    using Infrastructure.Services.ElasticSearch;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The class containing all the dependency injections of the Infrastructure layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Method to set the dependency injections for the database.
        /// </summary>
        /// <param name="services">IServiceCollection object.</param>
        /// <returns>Return a IServiceCollection</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<VictoriaContext>(options =>
                    options.UseSqlServer(
                        Environment.GetEnvironmentVariable("DatabaseConnectionString"),
                        b => b.MigrationsAssembly(typeof(VictoriaContext).Assembly.FullName)));

            services.AddScoped<IVictoriaContext>(provider => provider.GetService<VictoriaContext>());

            services.AddScoped<IElasticClientProvider, ElasticClientProvider>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IIndexService, IndexService>();

            return services;
        }
    }
}