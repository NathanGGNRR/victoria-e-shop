//-----------------------------------------------------------------------
// <copyright file="Vscategory.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
#nullable disable
namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The category of a product
    /// </summary>
    public partial class Vscategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vscategory" /> class.
        /// </summary>
        public Vscategory()
        {
            this.Vsproducts = new HashSet<Vsproduct>();
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public virtual ICollection<Vsproduct> Vsproducts { get; set; }
    }
}