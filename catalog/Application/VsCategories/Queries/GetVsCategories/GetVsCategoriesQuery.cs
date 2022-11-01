//-----------------------------------------------------------------------
// <copyright file="GetVsCategoriesQuery.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsCategories.Queries.GetVsCategories
{
    using Application.Common.Dto;
    using Application.Common.Models;
    using MediatR;

    /// <summary>
    /// The class containing all the categories queries.
    /// </summary>
    public class GetVsCategoriesQuery : IRequest<PaginatedList<VsCategoryDto>>
    {
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