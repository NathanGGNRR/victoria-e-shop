//-----------------------------------------------------------------------
// <copyright file="CreateVsProductCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsProducts.Commands.CreateVsProduct
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;

    /// <summary>
    /// Product creation command handler.
    /// </summary>
    public class CreateVsProductCommandHandler : IRequestHandler<CreateVsProductCommand, int>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVsProductCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public CreateVsProductCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the creation request.
        /// </summary>
        /// <param name="request">Creation request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The id of the created product.</returns>
        public async Task<int> Handle(CreateVsProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Vsproduct
            {
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                ProductName = request.ProductName,
                ProductUrl = request.ProductUrl
            };

            this.context.Vsproducts.Add(entity);

            await this.context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
