//-----------------------------------------------------------------------
// <copyright file="DeleteVsProductCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsProducts.Commands.DeleteVsProduct
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
    /// Delete product command handler.
    /// </summary>
    public class DeleteVsProductCommandHandler : IRequestHandler<DeleteVsProductCommand>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteVsProductCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public DeleteVsProductCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the delete request.
        /// </summary>
        /// <param name="request">Request to handle.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Unit value.</returns>
        public async Task<Unit> Handle(DeleteVsProductCommand request, CancellationToken cancellationToken)
        {
            var product = await this.context.Vsproducts.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(Vsproduct), request.Id);
            }

            this.context.Vsproducts.Remove(product);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}