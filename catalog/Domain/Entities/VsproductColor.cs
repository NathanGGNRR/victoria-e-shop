//-----------------------------------------------------------------------
// <copyright file="VsproductColor.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
#nullable disable
namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The color of a product.
    /// </summary>
    public partial class VsproductColor
    {
        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the ColorId.
        /// </summary>
        public int ColorId { get; set; }

        /// <summary>
        /// Gets or sets the Color.
        /// </summary>
        public virtual Vscolor Color { get; set; }

        /// <summary>
        /// Gets or sets the Product.
        /// </summary>
        public virtual Vsproduct Product { get; set; }
    }
}