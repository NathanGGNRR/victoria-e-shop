//-----------------------------------------------------------------------
// <copyright file="DeleteVsReviewCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsReviews.Commands.DeleteReview
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
    public class DeleteVsReviewCommandHandler : IRequestHandler<DeleteVsReviewCommand>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteVsReviewCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public DeleteVsReviewCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the delete request.
        /// </summary>
        /// <param name="request">Request to handle.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Unit value.</returns>
        public async Task<Unit> Handle(DeleteVsReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await this.context.VsproductReviews.FirstOrDefaultAsync(pr => pr.Id == request.Id, cancellationToken);

            if (review == null)
            {
                throw new NotFoundException(nameof(VsproductReview), request.Id);
            }

            this.context.VsproductReviews.Remove(review);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}