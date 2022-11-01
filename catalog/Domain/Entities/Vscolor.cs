//-----------------------------------------------------------------------
// <copyright file="Vscolor.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
#nullable disable
namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The color available
    /// </summary>
    public partial class Vscolor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vscolor" /> class.
        /// </summary>
        public Vscolor()
        {
            this.VsproductColors = new HashSet<VsproductColor>();
            this.VsproductPrices = new HashSet<VsproductPrice>();
            this.VsproductReviews = new HashSet<VsproductReview>();
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ColorName.
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// Gets or sets the ColorCode.
        /// </summary>
        public string ColorCode { get; set; }

        /// <summary>
        /// Gets or sets the product's colors.
        /// </summary>
        public virtual ICollection<VsproductColor> VsproductColors { get; set; }

        /// <summary>
        /// Gets or sets the product's prices.
        /// </summary>
        public virtual ICollection<VsproductPrice> VsproductPrices { get; set; }

        /// <summary>
        /// Gets or sets the product's reviews.
        /// </summary>
        public virtual ICollection<VsproductReview> VsproductReviews { get; set; }
    }
}