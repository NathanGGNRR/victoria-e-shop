//-----------------------------------------------------------------------
// <copyright file="GetVsReviewsQueryHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsReviews.Queries.GetVsReviews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Interfaces;
    using Application.Common.Mappings;
    using Application.Common.Models;
    using Application.Generic.Queries;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;

    /// <summary>
    /// The ReviewsQuery handler.
    /// </summary>
    public class GetVsReviewsQueryHandler : IRequestHandler<GetVsReviewsQuery, PaginatedList<VsReviewDto>>
    {
        /// <summary>
        /// IVictoriaContext instance.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// IMapper instance.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetVsReviewsQueryHandler" /> class.
        /// </summary>
        /// <param name="context">IVictoriaContext object.</param>
        /// <param name="mapper">IMapper object.</param>
        public GetVsReviewsQueryHandler(IVictoriaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Method to handler the query.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Return a IEnumerable of ReviewDTO</returns>
        public async Task<PaginatedList<VsReviewDto>> Handle(GetVsReviewsQuery request, CancellationToken cancellationToken)
        {
            return await this.context.VsproductReviews
                .Where(r => r.ProductId == request.ProductId)
                .ProjectTo<VsReviewDto>(this.mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
