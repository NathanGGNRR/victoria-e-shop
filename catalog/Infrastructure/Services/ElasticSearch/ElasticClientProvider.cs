//-----------------------------------------------------------------------
// <copyright file="ElasticClientProvider.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Infrastructure.Services.ElasticSearch
{
    using System;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using Nest;

    /// <summary>
    /// Elastic client provider.
    /// </summary>
    public class ElasticClientProvider : IElasticClientProvider
    {
        /// <summary>
        /// Gets elastic client.
        /// </summary>
        /// <returns>Elastic client.</returns>
        public IElasticClient Get()
        {
            var uri = new Uri(Environment.GetEnvironmentVariable("ElasticSearchUrl"));
            var setting = new ConnectionSettings(uri)
                .EnableDebugMode()
                .DisableDirectStreaming()
                .DefaultMappingFor<Vsproduct>(dmf => dmf.Ignore(i => i.BrandId).Ignore(i => i.CategoryId));
            return new ElasticClient(setting);
        }
    }
}