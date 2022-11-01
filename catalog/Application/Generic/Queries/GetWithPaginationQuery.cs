//-----------------------------------------------------------------------
// <copyright file="GetWithPaginationQuery.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Generic.Queries
{
    using Application.Common.Models;
    using MediatR;

    /// <summary>
    /// Generic query with pagination. 
    /// </summary>
    /// <typeparam name="T">Entity that will be treated.</typeparam>
    public class GetWithPaginationQuery<T> : IRequest<PaginatedList<T>>
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
