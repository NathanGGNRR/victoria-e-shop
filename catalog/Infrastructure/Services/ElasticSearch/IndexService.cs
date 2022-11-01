//-----------------------------------------------------------------------
// <copyright file="IndexService.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Infrastructure.Services.ElasticSearch
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Exceptions;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities;
    using Domain.Enums;
    using Microsoft.EntityFrameworkCore;
    using Nest;

    /// <summary>
    /// Service that manages indexes.
    /// </summary>
    public class IndexService : IIndexService
    {
        /// <summary>
        /// Elastic client.
        /// </summary>
        private readonly IElasticClient elasticClient;

        /// <summary>
        /// Database context.
        /// </summary>
        private readonly IVictoriaContext victoriaContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexService"/> class.
        /// </summary>
        /// <param name="elasticClientProvider">Elastic client provider.</param>
        /// <param name="victoriaContext">Database context.</param>
        public IndexService(IElasticClientProvider elasticClientProvider, IVictoriaContext victoriaContext)
        {
            this.elasticClient = elasticClientProvider.Get();
            this.victoriaContext = victoriaContext;
        }

        /// <summary>
        /// Creates an index.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A boolean.</returns>
        public async Task<bool> CreateIndex(CancellationToken ct)
        {
            var indexName = "product";
            var analyzerName = "string_product";

            List<Vsproduct> products = await this.victoriaContext.Vsproducts.Where(w => w.CategoryId != null)
                .Include(i => i.Category)
                .AsNoTracking()
                .ToListAsync(ct);
            products.ForEach(p => p.Category.Vsproducts = null);

            // Creates the index.
            var response = await this.elasticClient.Indices.CreateAsync(indexName, c => c.Settings(s => s.Analysis(a => a.Analyzers(an => an.Custom(analyzerName, sp => sp.Tokenizer("standard").Filters("lowercase", "stop", "stemmer"))))).Map<Vsproduct>(m => m.Properties(props => props.Text(t => t.Name(n => n.ProductName).Analyzer(analyzerName)).Text(t => t.Name(n => n.Description).Analyzer(analyzerName)).Number(nu => nu.Name(n => n.Id).Index(false)).Text(t => t.Name(n => n.ImageUrl).Index(false)).Text(t => t.Name(n => n.ProductUrl).Index(false)).Nested<Vscategory>(o => o.Name(na => na.Category).Properties(po => po.Keyword(te => te.Name(na => na.CategoryName)))))), ct);

            // Adds products and their categories to the index.
            await this.elasticClient.IndexManyAsync(products, indexName, ct);
            await this.elasticClient.Indices.RefreshAsync(indexName, ct: ct);

            return ErrorHandler(response);
        }

        /// <summary>
        /// Index documents.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A boolean.</returns>
        public async Task<bool> DeleteIndex(CancellationToken ct)
        {
            var response = await this.elasticClient.Indices.DeleteAsync("product", ct: ct);
            return ErrorHandler(response);
        }

        /// <summary>
        /// Checks for the validity of the response.
        /// </summary>
        /// <param name="response">Base response.</param>
        /// <returns>A boolean.</returns>
        private static bool ErrorHandler(ResponseBase response)
        {
            if (!response.IsValid)
            {
                throw new ElasticException(response.ServerError.Error.Reason);
            }

            return response.IsValid;
        }
    }
}