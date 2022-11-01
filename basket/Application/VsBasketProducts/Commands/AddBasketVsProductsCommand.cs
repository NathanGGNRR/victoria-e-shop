//-----------------------------------------------------------------------
// <copyright file="AddBasketVsProductsCommand.cs" company="Diiage">
//    Diiage
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsBasketProducts.Commands
{
    using Application.Common.Dto;
    using MediatR;

    public class AddBasketVsProductsCommand : IRequest<VsBasketDto>
    {
        /// <summary>
        /// Gets or sets Id of the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name of the product.
        /// </summary>
        public string  Name { get; set; }

        /// <summary>
        /// Gets or sets Description of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Price of the product.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets Image of the product.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientKey { get; set; }

        public int Qantite { get; set; }

        public string Taille { get; set; }

        public string Couleur { get; set; }
    }
}
