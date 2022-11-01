//-----------------------------------------------------------------------
// <copyright file="GetVsProductDetailQueryHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsProducts.Queries.GetVsProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The ProductDetailQuery handler.
    /// </summary>
    public class GetVsProductDetailQueryHandler : IRequestHandler<GetVsProductDetailQuery, VsProductDetailDto>
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
        /// Initializes a new instance of the <see cref="GetVsProductDetailQueryHandler" /> class.
        /// </summary>
        /// <param name="context">IVictoriaContext object.</param>
        /// <param name="mapper">IMapper object.</param>
        public GetVsProductDetailQueryHandler(IVictoriaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Method to handler the query.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Return a ProductDetailDTO</returns>
        public async Task<VsProductDetailDto> Handle(GetVsProductDetailQuery request, CancellationToken cancellationToken)
        {
            return await this.context.Vsproducts.AsNoTracking().ProjectTo<VsProductDetailDto>(this.mapper.ConfigurationProvider).Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}