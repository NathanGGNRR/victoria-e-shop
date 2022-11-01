//-----------------------------------------------------------------------
// <copyright file="VsproductSize.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
#nullable disable
namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The size of a product.
    /// </summary>
    public partial class VsproductSize
    {
        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the SizeId.
        /// </summary>
        public int SizeId { get; set; }

        /// <summary>
        /// Gets or sets the Product.
        /// </summary>
        public virtual Vsproduct Product { get; set; }

        /// <summary>
        /// Gets or sets the Size.
        /// </summary>
        public virtual Vssize Size { get; set; }
    }
}