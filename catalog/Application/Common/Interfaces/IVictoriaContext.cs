//-----------------------------------------------------------------------
// <copyright file="IVictoriaContext.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The interface for the VictoriaContext.
    /// </summary>
    public interface IVictoriaContext
    {
        /// <summary>
        /// Gets or sets the brands.
        /// </summary>
        DbSet<Vsbrand> Vsbrands { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        DbSet<Vscategory> Vscategories { get; set; }

        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        DbSet<Vscolor> Vscolors { get; set; }

        /// <summary>
        /// Gets or sets the indices.
        /// </summary>
        DbSet<Vsindex> Vsindices { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        DbSet<Vsproduct> Vsproducts { get; set; }

        /// <summary>
        /// Gets or sets the product's colors.
        /// </summary>
        DbSet<VsproductColor> VsproductColors { get; set; }

        /// <summary>
        /// Gets or sets the product's prices.
        /// </summary>
        DbSet<VsproductPrice> VsproductPrices { get; set; }

        /// <summary>
        /// Gets or sets the product's reviews.
        /// </summary>
        DbSet<VsproductReview> VsproductReviews { get; set; }

        /// <summary>
        /// Gets or sets the product's search indices.
        /// </summary>
        DbSet<VsproductSearchIndex> VsproductSearchIndices { get; set; }

        /// <summary>
        /// Gets or sets the product's sizes.
        /// </summary>
        DbSet<VsproductSize> VsproductSizes { get; set; }

        /// <summary>
        /// Gets or sets the retailers.
        /// </summary>
        DbSet<Vsretailer> Vsretailers { get; set; }

        /// <summary>
        /// Gets or sets the sizes.
        /// </summary>
        DbSet<Vssize> Vssizes { get; set; }

        /// <summary>
        /// Method to save the changes made in the database.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A integer.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}