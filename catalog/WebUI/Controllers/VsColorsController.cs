//-----------------------------------------------------------------------
// <copyright file="VsColorsController.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace WebUI.Controllers
{
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Models;
    using Application.Generic.Queries;
    using Application.VsColors.Commands.CreateVsColor;
    using Application.VsColors.Commands.DeleteVsColor;
    using Application.VsColors.Commands.UpdateVsColor;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// API controller for the VSColors.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    public class VsColorsController : ApiBaseController
    {
        /// <summary>
        /// Gets all colors.
        /// </summary>
        /// <param name="query">Query used.</param>
        /// <returns>A paginated list of colors.</returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<VsColorDto>>> GetAllVsColors([FromQuery] GetWithPaginationQuery<VsColorDto> query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Creates a new color.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        /// <returns>The id of the created color.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVsColorCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Updates a color.
        /// </summary>
        /// <param name="command">Command to run.</param>
        /// <returns>An empty result.</returns>
        [HttpPut]
        public async Task<ActionResult> Update(UpdateVsColorCommand command)
        {
            await Mediator.Send(command);

            return this.NoContent();
        }

        /// <summary>
        /// Deletes a color.
        /// </summary>
        /// <param name="id">Id of the color to delete.</param>
        /// <returns>An empty result.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteVsColorCommand { Id = id });

            return this.NoContent();
        }
    }
}