//-----------------------------------------------------------------------
// <copyright file="CreateVsProductCommand.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsProducts.Commands.CreateVsProduct
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MediatR;

    /// <summary>
    /// Product creation command.
    /// </summary>
    public class CreateVsProductCommand : IRequest<int>
    {
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
