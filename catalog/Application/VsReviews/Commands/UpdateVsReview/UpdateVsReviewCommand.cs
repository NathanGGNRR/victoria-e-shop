//-----------------------------------------------------------------------
// <copyright file="UpdateVsReviewCommand.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsReviews.Commands.UpdateVsReview
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MediatR;

    /// <summary>
    /// Product update command.
    /// </summary>
    public class UpdateVsReviewCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// Gets or sets the SizeId.
        /// </summary>
        public int? SizeId { get; set; }

        /// <summary>
        /// Gets or sets the ColorId.
        /// </summary>
        public int? ColorId { get; set; }

        /// <summary>
        /// Gets or sets the Rating.
        /// </summary>
        public decimal? Rating { get; set; }

        /// <summary>
        /// Gets or sets the reviewCount.
        /// </summary>
        public int? ReviewCount { get; set; }
    }
}
