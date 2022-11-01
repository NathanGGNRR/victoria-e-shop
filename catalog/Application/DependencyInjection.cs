//-----------------------------------------------------------------------
// <copyright file="DependencyInjection.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application
{
    using System.Reflection;
    using Application.Common.Interfaces;
    using Application.ElasticSearch;
    using Application.ElasticSearch.Interfaces;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The class containing all the dependency injections of the Application layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Method starting the injections.
        /// </summary>
        /// <param name="services">A IServiceCollection object.</param>
        /// <returns>Returns a IServiceCollection.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}