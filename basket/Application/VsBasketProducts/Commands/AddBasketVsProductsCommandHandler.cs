namespace Application.VsBasketProducts.Commands
{
    using Application.Common.Dto;
    using Application.Common.Interfaces;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddBasketVsProductsCommandHandler : IRequestHandler<AddBasketVsProductsCommand, VsBasketDto>
    {
        private readonly IRedisService redis;

        public AddBasketVsProductsCommandHandler(IRedisService redis)
        {
            this.redis = redis;
        }

        /// <summary>
        /// Get the 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<VsBasketDto> Handle(AddBasketVsProductsCommand request, CancellationToken cancellationToken)
        {
            var product = new VsBasketProductDto
            {
                Id = request.Id,
                ProductName = request.Name,
                Description = request.Description,
                Price = request.Price,
                Image = request.Image,
                Couleur = request.Couleur,
                Taille = request.Taille,
                Quantite = request.Qantite
            };

            var clientBasket = await this.redis.Get<VsBasketDto>(request.ClientKey);

            if (clientBasket == null)
            {
                clientBasket = new VsBasketDto();
                clientBasket.Products = new List<VsBasketProductDto>();
            }

            var existingProduct = clientBasket.Products.Find(p => p.Id == product.Id && p.Couleur == product.Couleur && p.Taille == product.Taille);

            if (existingProduct != null)
            {
                clientBasket.Products.Remove(existingProduct);
                clientBasket.Products.Add(product);
            }
            else
            {
                clientBasket.Products.Add(product);
            }

            return this.redis.Set(request.ClientKey, clientBasket);
        }
    }
}
