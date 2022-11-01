//-----------------------------------------------------------------------
// <copyright file="SearchController.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace WebUI.Controllers
{
    using System.Threading.Tasks;
    using Application.ElasticSearch.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Nest;

    /// <summary>
    /// API controller for search.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    public class SearchController : ApiBaseController
    {
        /// <summary>
        /// Search service to use.
        /// </summary>
        private readonly ISearchService searchService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchController"/> class.
        /// </summary>
        /// <param name="searchService">Search service.</param>
        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        /// <summary>
        /// Search for a list of products.
        /// </summary>
        /// <param name="query">String to search.</param>
        /// <param name="size">Number of wanted results.</param>
        /// <returns>A list of products.</returns>
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query = "panties", [FromQuery] int size = 25)
        {
            var result = await this.searchService.SearchAsync(query, size, HttpContext.RequestAborted);
            return this.Ok(result);
        }

        /// <summary>
        /// Gets the facet.
        /// </summary>
        /// <returns>A facet.</returns>
        [HttpGet("facet")]
        public async Task<IActionResult> Facet()
        {
            var result = await this.searchService.GetFacet();
            return this.Ok(result);
        }

        /// <summary>
        /// Suggests products corresponding to the query.
        /// </summary>
        /// <param name="query">Query to find.</param>
        /// <returns>A list of suggests.</returns>
        [HttpGet("suggests")]
        public async Task<IActionResult> Suggests([FromQuery] string query = "victor")
        {
            return this.Ok(await this.searchService.GetSuggests(query));
        }
    }
}