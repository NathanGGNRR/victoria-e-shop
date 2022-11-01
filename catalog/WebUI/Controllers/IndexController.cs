//-----------------------------------------------------------------------
// <copyright file="IndexController.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace WebUI.Controllers
{
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Enums;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// API controller for index management.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    public class IndexController : ApiBaseController
    {
        /// <summary>
        /// Index service used.
        /// </summary>
        private readonly IIndexService indexService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexController"/> class.
        /// </summary>
        /// <param name="indexService">Index service.</param>
        public IndexController(IIndexService indexService)
        {
            this.indexService = indexService;
        }

        /// <summary>
        /// Creates a new index.
        /// </summary>
        /// <returns>An async result.</returns>
        [HttpPost("create")]
        public async Task CreateIndex()
        {
            await this.indexService.CreateIndex(HttpContext.RequestAborted);
        }

        /// <summary>
        /// Deletes an index.
        /// </summary>
        /// <returns>An async result.</returns>
        [HttpPost("delete")]
        public async Task DeleteIndex()
        {
            await this.indexService.DeleteIndex(HttpContext.RequestAborted);
        }
    }
}