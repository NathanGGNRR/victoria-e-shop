//-----------------------------------------------------------------------
// <copyright file="ISearchService.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.ElasticSearch.Interfaces
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Models.Facet;
    using Domain.Entities;
    using Nest;

    /// <summary>
    /// Interface for search service.
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Asynchronous search for products.
        /// </summary>
        /// <param name="query">Query to execute.</param>
        /// <param name="size">Number of results to get.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A list of products.</returns>
        Task<IEnumerable<Vsproduct>> SearchAsync(string query, int size, CancellationToken ct = default);

        /// <summary>
        /// Get the facet items.
        /// </summary>
        /// <returns>All facet items.</returns>
        Task<IEnumerable<Common.Models.Facet.Bucket>> GetFacet();

        /// <summary>
        /// Gets or sets the suggests corresponding to the query.
        /// </summary>
        /// <param name="query">Query to find.</param>
        /// <returns>A list of suggests.</returns>
        Task<ISuggest<Vsproduct>[]> GetSuggests(string query);
    }
}