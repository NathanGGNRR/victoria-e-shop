//-----------------------------------------------------------------------
// <copyright file="Vsretailer.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
#nullable disable
namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The retailer of a product.
    /// </summary>
    public partial class Vsretailer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vsretailer" /> class.
        /// </summary>
        public Vsretailer()
        {
            this.VsproductPrices = new HashSet<VsproductPrice>();
        }

        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the RetailerName.
        /// </summary>
        public string RetailerName { get; set; }

        /// <summary>
        /// Gets or sets the product's prices.
        /// </summary>
        public virtual ICollection<VsproductPrice> VsproductPrices { get; set; }
    }
}