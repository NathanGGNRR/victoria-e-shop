//-----------------------------------------------------------------------
// <copyright file="GetVsBasketProductsQueryHandler.cs" company="Diiage">
//    Diiage
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsBasketProducts.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;

    /// <summary>
    /// Handler of the query.
    /// </summary>
    public class GetVsBasketProductsQueryHandler : IRequestHandler<GetVsBasketProductsQuery, VsBasketDto>
    {
        /// <summary>
        /// IVictoriaContext instance.
        /// </summary>
        private readonly IRedisService redis;

        /// <summary>
        /// IMapper instance.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetVsBasketProductsQueryHandler" /> class.
        /// </summary>
        /// <param name="redis">Instance of <see cref="IRedisService"/> class.</param>
        /// <param name="mapper">Instance of IMapper class.</param>
        public GetVsBasketProductsQueryHandler(IRedisService redis, IMapper mapper)
        {
            this.redis = redis;
            this.mapper = mapper;
        }

        /// <summary>
        /// Method to handler the query.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Return a IEnumerable of ProductDTO</returns>
        public async Task<VsBasketDto> Handle(GetVsBasketProductsQuery request, CancellationToken cancellationToken)
        {
            return await this.redis.Get<VsBasketDto>(request.Item);
        }
    }
}
