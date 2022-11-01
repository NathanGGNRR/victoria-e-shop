//-----------------------------------------------------------------------
// <copyright file="VsproductPrice.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
#nullable disable
namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The price of a product.
    /// </summary>
    public partial class VsproductPrice
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// Gets or sets the SizeId.
        /// </summary>
        public int? SizeId { get; set; }

        /// <summary>
        /// Gets or sets the RetailerId.
        /// </summary>
        public int? RetailerId { get; set; }

        /// <summary>
        /// Gets or sets the ColorId.
        /// </summary>
        public int? ColorId { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the StockQuantity.
        /// </summary>
        public int? StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the Color.
        /// </summary>
        public virtual Vscolor Color { get; set; }

        /// <summary>
        /// Gets or sets the Product.
        /// </summary>
        public virtual Vsproduct Product { get; set; }

        /// <summary>
        /// Gets or sets the Retailer.
        /// </summary>
        public virtual Vsretailer Retailer { get; set; }

        /// <summary>
        /// Gets or sets the Size.
        /// </summary>
        public virtual Vssize Size { get; set; }
    }
}