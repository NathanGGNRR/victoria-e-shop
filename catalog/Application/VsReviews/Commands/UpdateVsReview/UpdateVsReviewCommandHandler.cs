//-----------------------------------------------------------------------
// <copyright file="UpdateVsReviewCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsReviews.Commands.UpdateVsReview
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
    /// Handler for review update.
    /// </summary>
    public class UpdateVsReviewCommandHandler : IRequestHandler<UpdateVsReviewCommand>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVsReviewCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public UpdateVsReviewCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the update request.
        /// </summary>
        /// <param name="request">Request to handle.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The updated object.</returns>
        public async Task<Unit> Handle(UpdateVsReviewCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.context.VsproductReviews.FirstOrDefaultAsync(pr => pr.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(VsproductReview), request.Id);
            }

            entity.ProductId = request.ProductId;
            entity.ColorId = request.ColorId;
            entity.SizeId = request.SizeId;
            entity.Rating = request.Rating;
            entity.ReviewCount = request.ReviewCount;

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}