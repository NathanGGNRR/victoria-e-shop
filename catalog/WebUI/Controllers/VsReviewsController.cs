//-----------------------------------------------------------------------
// <copyright file="VsReviewsController.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace WebUI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Models;
    using Application.Generic.Queries;
    using Application.VsReviews.Commands.CreateVsReview;
    using Application.VsReviews.Commands.DeleteReview;
    using Application.VsReviews.Commands.UpdateVsReview;
    using Application.VsReviews.Queries.GetVsReviews;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// API Controller for the VSProducts.
    /// </summary>
    /// 
    [ApiController]
    [ApiVersion("1.0")]
    public class VsReviewsController : ApiBaseController
    {
        /// <summary>
        /// Get the reviews of a product.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Returns a list of Reviews.</returns>
        [HttpGet]
        public async Task<PaginatedList<VsReviewDto>> Get([FromQuery] GetVsReviewsQuery query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Creates a new review.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        /// <returns>The id of the created review.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVsReviewCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Updates a review.
        /// </summary>
        /// <param name="command">Command to run.</param>
        /// <returns>An empty result.</returns>
        [HttpPut]
        public async Task<ActionResult> Update(UpdateVsReviewCommand command)
        {
            await Mediator.Send(command);

            return this.NoContent();
        }

        /// <summary>
        /// Deletes a review.
        /// </summary>
        /// <param name="id">Id of the review to delete.</param>
        /// <returns>An empty result.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteVsReviewCommand { Id = id });

            return this.NoContent();
        }
    }
}
