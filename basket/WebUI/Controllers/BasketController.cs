namespace WebUI.Controllers
{
    using Application.Common.Dto;
    using Application.VsBasketProducts.Commands;
    using Application.VsBasketProducts.Queries;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BasketController : ApiBaseController
    {
        /// <summary>
        /// Get the basket content.
        /// </summary>
        /// <param name="query">Current query.</param>
        /// <returns>The database item.</returns>
        [HttpGet]
        public async Task<VsBasketDto> GetAllVsBasketProducts ([FromQuery] GetVsBasketProductsQuery query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Insert in the database.
        /// </summary>
        /// <param name="command">Current command.</param>
        /// <returns>The added item.</returns>
        [HttpPost]
        public async Task<ActionResult<VsBasketDto>> Create(AddBasketVsProductsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult<VsBasketDto>> Delete(RemoveBasketVsProductsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("all")]
        public async Task<ActionResult<VsBasketDto>> DeleteBasket(RemoveBasketCommand command)
        {
            return await Mediator.Send(command);
        }


    }
}
