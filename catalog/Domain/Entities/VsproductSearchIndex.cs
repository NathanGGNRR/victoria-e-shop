//-----------------------------------------------------------------------
// <copyright file="VsproductSearchIndex.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
#nullable disable
namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The search index of a product.
    /// </summary>
    public partial class VsproductSearchIndex
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
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the BrandName.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the ColorName.
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// Gets or sets the SizeName.
        /// </summary>
        public string SizeName { get; set; }

        /// <summary>
        /// Gets or sets the ImageUrl.
        /// </summary>
        public string ImageUrl { get; set; }
    }
}