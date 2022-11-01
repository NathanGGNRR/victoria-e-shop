//-----------------------------------------------------------------------
// <copyright file="GetVsCategoriesQueryHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsCategories.Queries.GetVsCategories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Interfaces;
    using Application.Common.Mappings;
    using Application.Common.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;

    /// <summary>
    /// The ProductsQuery handler.
    /// </summary>
    public class GetVsCategoriesQueryHandler : IRequestHandler<GetVsCategoriesQuery, PaginatedList<VsCategoryDto>>
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
        /// Initializes a new instance of the <see cref="GetVsCategoriesQueryHandler" /> class.
        /// </summary>
        /// <param name="context">IVictoriaContext object.</param>
        /// <param name="mapper">IMapper object.</param>
        public GetVsCategoriesQueryHandler(IVictoriaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Method to handler the query.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Return a IEnumerable of CategoryDTO</returns>
        public async Task<PaginatedList<VsCategoryDto>> Handle(GetVsCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await this.context.Vscategories
                .ProjectTo<VsCategoryDto>(this.mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
