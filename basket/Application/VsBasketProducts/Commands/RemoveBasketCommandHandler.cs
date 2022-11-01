using Application.Common.Dto;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VsBasketProducts.Commands
{
    public class RemoveBasketCommandHandler : IRequestHandler<RemoveBasketCommand, VsBasketDto>
    {
        private readonly IRedisService redis;

        public RemoveBasketCommandHandler(IRedisService redis)
        {
            this.redis = redis;
        }

     
        public Task<VsBasketDto> Handle(RemoveBasketCommand request, CancellationToken cancellationToken)
        {
            var basketToDelete = this.redis.Get<VsBasketDto>(request.CLientKey);
            this.redis.Remove(request.CLientKey);
            return basketToDelete;
        }
    }
}
