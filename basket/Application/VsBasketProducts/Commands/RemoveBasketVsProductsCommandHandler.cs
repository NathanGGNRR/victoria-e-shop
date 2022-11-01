using Application.Common.Dto;
using Application.Common.Interfaces;
using MediatR;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VsBasketProducts.Commands
{
    public class RemoveBasketVsProductsCommandHandler : IRequestHandler<RemoveBasketVsProductsCommand, VsBasketDto>
    {
        private readonly IRedisService _redis;

        public RemoveBasketVsProductsCommandHandler(IRedisService redis)
        {
            this._redis = redis;
        }

        public async Task<VsBasketDto> Handle(RemoveBasketVsProductsCommand request, CancellationToken cancellationToken)
        {
            var clientBasket = await this._redis.Get<VsBasketDto>(request.ClientKey);
            var itemToDelete = clientBasket.Products.Find(p => p.Id == request.Id);
            clientBasket.Products.Remove(itemToDelete);
            return this._redis.Set<VsBasketDto>(request.ClientKey,clientBasket);
        }
    }
}