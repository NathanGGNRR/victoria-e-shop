//-----------------------------------------------------------------------
// <copyright file="Vssize.cs" company="DIIAGE">
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
    public partial class Vssize
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vssize" /> class.
        /// </summary>
        public Vssize()
        {
            this.VsproductPrices = new HashSet<VsproductPrice>();
            this.VsproductReviews = new HashSet<VsproductReview>();
            this.VsproductSizes = new HashSet<VsproductSize>();
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the SizeName.
        /// </summary>
        public string SizeName { get; set; }

        /// <summary>
        /// Gets or sets the product's prices.
        /// </summary>
        public virtual ICollection<VsproductPrice> VsproductPrices { get; set; }

        /// <summary>
        /// Gets or sets the product's reviews.
        /// </summary>
        public virtual ICollection<VsproductReview> VsproductReviews { get; set; }

        /// <summary>
        /// Gets or sets the product's sizes.
        /// </summary>
        public virtual ICollection<VsproductSize> VsproductSizes { get; set; }
    }
}