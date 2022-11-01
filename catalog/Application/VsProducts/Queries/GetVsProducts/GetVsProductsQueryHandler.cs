//-----------------------------------------------------------------------
// <copyright file="GetVsProductsQueryHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsProducts.Queries.GetVsProducts
{
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
    /// The ProductsQuery handler.
    /// </summary>
    public class GetVsProductsQueryHandler : IRequestHandler<GetWithPaginationQuery<VsProductDto>, PaginatedList<VsProductDto>>
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
        /// Initializes a new instance of the <see cref="GetVsProductsQueryHandler" /> class.
        /// </summary>
        /// <param name="context">IVictoriaContext object.</param>
        /// <param name="mapper">IMapper object.</param>
        public GetVsProductsQueryHandler(IVictoriaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Method to handler the query.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Return a paginated list of ProductDTO</returns>
        public async Task<PaginatedList<VsProductDto>> Handle(GetWithPaginationQuery<VsProductDto> request, CancellationToken cancellationToken)
        {
            return await this.context.Vsproducts
                .ProjectTo<VsProductDto>(this.mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
