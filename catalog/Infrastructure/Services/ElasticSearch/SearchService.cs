//-----------------------------------------------------------------------
// <copyright file="SearchService.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Infrastructure.Services.ElasticSearch
{
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Exceptions;
    using Application.Common.Interfaces;
    using Application.Common.Models.Facet;
    using Application.ElasticSearch.Interfaces;
    using Domain.Entities;
    using Elasticsearch.Net;
    using Nest;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements search service interface.
    /// </summary>
    public class SearchService : ISearchService
    {
        /// <summary>
        /// Elastic client used.
        /// </summary>
        private readonly IElasticClient elasticClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchService"/> class.
        /// </summary>
        /// <param name="provider">Elastic client provider.</param>
        public SearchService(IElasticClientProvider provider)
        {
            this.elasticClient = provider.Get();
        }

        /// <summary>
        /// Gets elements that will appear in facet.
        /// </summary>
        /// <returns>Facet items.</returns>
        public async Task<IEnumerable<Application.Common.Models.Facet.Bucket>> GetFacet()
        {
            var nestedName = "category";
            var termsName = "categoryNames";

            var aggregation = await this.elasticClient.SearchAsync<Vsproduct>(p => p.Index("product").Size(0).Aggregations(a => a.Nested(nestedName, n => n.Path(pa => pa.Category).Aggregations(ag => ag.Terms(termsName, t => t.Field(f => f.Category.Suffix("categoryName")).Size(50))))));

            if (!aggregation.ApiCall.Success)
            {
                throw new ElasticException(aggregation.OriginalException.Message);
            }

            var buckets = JsonConvert.DeserializeObject<Root>(Encoding.Default.GetString(aggregation.ApiCall.ResponseBodyInBytes)).Aggregations.Category.CategoryNames.Buckets;

            return buckets;
        }

        /// <summary>
        /// Gets suggests corresponding to the query.
        /// </summary>
        /// <param name="query">Query to find.</param>
        /// <returns>A list of suggests.</returns>
        public async Task<ISuggest<Vsproduct>[]> GetSuggests(string query)
        {
            var termName = "product_name";

            var suggestResponse = await this.elasticClient.SearchAsync<Vsproduct>(p => p.Index("product").Suggest(s => s.Term(termName, t => t.Field(f => f.ProductName).SuggestMode(SuggestMode.Always).ShardSize(7).Size(8).StringDistance(StringDistance.Levenshtein).Text(query))));

            if (!suggestResponse.ApiCall.Success)
            {
                throw new ElasticException(suggestResponse.OriginalException.Message);
            }

            return suggestResponse.Suggest[termName];
        }

        /// <summary>
        /// Gets products corresponding to the string entered.
        /// </summary>
        /// <param name="query">Value to search.</param>
        /// <param name="size">Number of wanted results.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A list of products.</returns>
        public async Task<IEnumerable<Vsproduct>> SearchAsync(string query, int size, CancellationToken ct = default)
        {
            var searchResponse = await this.elasticClient.SearchAsync<Vsproduct>(p => p.Index("product").Query(q => q.DisMax(dm => dm.Queries(qu => qu.Match(m => m.Field(f => f.ProductName).Boost(3).Fuzziness(Fuzziness.EditDistance(2)).Query(query)), qu => qu.Match(m => m.Field(f => f.Description).Fuzziness(Fuzziness.EditDistance(2)).Query(query))))).Size(size), ct);

            if (!searchResponse.ApiCall.Success)
            {
                throw new ElasticException(searchResponse.OriginalException.Message);
            }

            return searchResponse.Documents;
        }
    }
}