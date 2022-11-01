//-----------------------------------------------------------------------
// <copyright file="Vsproduct.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
#nullable disable
namespace Domain.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// The details of a product.
    /// </summary>
    public partial class Vsproduct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vsproduct" /> class.
        /// </summary>
        public Vsproduct()
        {
            this.VsproductColors = new HashSet<VsproductColor>();
            this.VsproductPrices = new HashSet<VsproductPrice>();
            this.VsproductReviews = new HashSet<VsproductReview>();
            this.VsproductSizes = new HashSet<VsproductSize>();
        }

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

        /// <summary>
        /// Gets or sets the Brand.
        /// </summary>
        public virtual Vsbrand Brand { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        public virtual Vscategory Category { get; set; }

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

        /// <summary>
        /// Gets or sets the product's sizes.
        /// </summary>
        public virtual ICollection<VsproductSize> VsproductSizes { get; set; }
    }
}