//-----------------------------------------------------------------------
// <copyright file="GetVsReviewsQuery.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsReviews.Queries.GetVsReviews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Models;
    using MediatR;

    /// <summary>
    /// The class containing all the reviews queries
    /// </summary>
    public class GetVsReviewsQuery : IRequest<PaginatedList<VsReviewDto>>
    {
        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the PageNumber.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the PageSize.
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}
