//-----------------------------------------------------------------------
// <copyright file="Vsbrand.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
#nullable disable
namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The brand of a product
    /// </summary>
    public partial class Vsbrand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vsbrand" /> class.
        /// </summary>
        public Vsbrand()
        {
            this.Vsproducts = new HashSet<Vsproduct>();
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the BrandName.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public virtual ICollection<Vsproduct> Vsproducts { get; set; }
    }
}