//-----------------------------------------------------------------------
// <copyright file="GetVsBasketProductsQuery.cs" company="Diiage">
//    Diiage
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsBasketProducts.Queries
{
    using Application.Common.Dto;
    using MediatR;

    /// <summary>
    /// Query for Basket Product.
    /// </summary>
    public class GetVsBasketProductsQuery : IRequest<VsBasketDto>
    {
        /// <summary>
        /// Gets or sets the queue
        /// </summary>
        public string Item { get; set; } = "client";
    }
}
