//-----------------------------------------------------------------------
// <copyright file="VsProductsController.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace WebUI.Controllers
{
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Models;
    using Application.Generic.Queries;
    using Application.VsProducts.Commands.CreateVsProduct;
    using Application.VsProducts.Commands.DeleteVsProduct;
    using Application.VsProducts.Commands.UpdateVsProduct;
    using Application.VsProducts.Queries.GetVsProducts;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// API Controller for the VSProducts.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    public class VsProductsController : ApiBaseController
    {
        /// <summary>
        /// Get all the products.
        /// </summary>
        /// <param name="query">GetProductsQuery object.</param>
        /// <returns>Returns a IEnumerable of ProductDTO</returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<VsProductDto>>> GetAllVsProducts([FromQuery] GetWithPaginationQuery<VsProductDto> query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Get the details of a product.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <returns>Returns a </returns>
        [HttpGet("{id}")]
        public async Task<VsProductDetailDto> Get(int id)
        {
            return await Mediator.Send(new GetVsProductDetailQuery { Id = id });
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        /// <returns>The id of the created product.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVsProductCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="command">Command to run.</param>
        /// <returns>An empty result.</returns>
        [HttpPut]
        public async Task<ActionResult> Update(UpdateVsProductCommand command)
        {
            await Mediator.Send(command);

            return this.NoContent();
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">Id of the product to delete.</param>
        /// <returns>An empty result.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteVsProductCommand { Id = id });

            return this.NoContent();
        }
    }
}