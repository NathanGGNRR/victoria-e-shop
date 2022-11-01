//-----------------------------------------------------------------------
// <copyright file="UpdateVsProductCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsProducts.Commands.UpdateVsProduct
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Exceptions;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Handler for product update.
    /// </summary>
    public class UpdateVsProductCommandHandler : IRequestHandler<UpdateVsProductCommand>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVsProductCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public UpdateVsProductCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the update request.
        /// </summary>
        /// <param name="request">Request to handle.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The updated object.</returns>
        public async Task<Unit> Handle(UpdateVsProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.context.Vsproducts.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Vsproduct), request.Id);
            }

            entity.ImageUrl = request.ImageUrl;
            entity.ProductName = request.ProductName;
            entity.ProductUrl = request.ProductUrl;
            entity.BrandId = request.BrandId;
            entity.CategoryId = request.CategoryId;
            entity.Description = request.Description;

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}