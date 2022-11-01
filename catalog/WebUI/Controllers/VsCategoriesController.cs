//-----------------------------------------------------------------------
// <copyright file="VsCategoriesController.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace WebUI.Controllers
{
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Models;
    using Application.VsCategories.Commands.CreateVsCategory;
    using Application.VsCategories.Commands.UpdateVsCategory;
    using Application.VsCategories.Queries.GetVsCategories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// API Controller for the VSCategory.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    public class VsCategoriesController : ApiBaseController
    {
        /// <summary>
        /// Get all the categories.
        /// </summary>
        /// <param name="query">GetCategoriesQuery object.</param>
        /// <returns>Returns a IEnumerable of CategoryDTO</returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<VsCategoryDto>>> GetAllVsCategories([FromQuery] GetVsCategoriesQuery query)
        {
            // Cancellation token example.
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        /// <returns>The id of the created category.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVsCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Updates a color.
        /// </summary>
        /// <param name="command">Command UpdateCategoryCommand to run .</param>
        /// <returns>An empty result.</returns>
        [HttpPut]
        public async Task<ActionResult> Update(UpdateVsCategoryCommand command)
        {
            await Mediator.Send(command);

            return this.NoContent();
        }
    }
}