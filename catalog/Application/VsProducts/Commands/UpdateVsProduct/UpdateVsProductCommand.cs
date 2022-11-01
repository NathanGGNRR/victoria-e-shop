//-----------------------------------------------------------------------
// <copyright file="UpdateVsProductCommand.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsProducts.Commands.UpdateVsProduct
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MediatR;

    /// <summary>
    /// Product update command.
    /// </summary>
    public class UpdateVsProductCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ProductName.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the ProductUrl.
        /// </summary>
        public string ProductUrl { get; set; }

        /// <summary>
        /// Gets or sets the BrandId.
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ImageUrl.
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
