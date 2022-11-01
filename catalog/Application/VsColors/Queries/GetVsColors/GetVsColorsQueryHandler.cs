//-----------------------------------------------------------------------
// <copyright file="GetVsColorsQueryHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsColors.Queries.GetVsColors
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
    /// Handler for query that gets colors. 
    /// </summary>
    public class GetVsColorsQueryHandler : IRequestHandler<GetWithPaginationQuery<VsColorDto>, PaginatedList<VsColorDto>>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Mapper used.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetVsColorsQueryHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="mapper">A mapper.</param>
        public GetVsColorsQueryHandler(IVictoriaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the request that gets colors.
        /// </summary>
        /// <param name="request">Request to handle.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A paginated list containing ColorDTO.</returns>
        public async Task<PaginatedList<VsColorDto>> Handle(GetWithPaginationQuery<VsColorDto> request, CancellationToken cancellationToken)
        {
            return await this.context.Vscolors
                .ProjectTo<VsColorDto>(this.mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
