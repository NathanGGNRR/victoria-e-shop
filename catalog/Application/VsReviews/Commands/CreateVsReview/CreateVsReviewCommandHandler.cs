//-----------------------------------------------------------------------
// <copyright file="CreateVsReviewCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsReviews.Commands.CreateVsReview 
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
    /// Review creation command handler.
    /// </summary>
    public class CreateVsReviewCommandHandler : IRequestHandler<CreateVsReviewCommand, int>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVsReviewCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public CreateVsReviewCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the creation request.
        /// </summary>
        /// <param name="request">Creation request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The id of the created review.</returns>
        public async Task<int> Handle(CreateVsReviewCommand request, CancellationToken cancellationToken)
        {
            var entity = new VsproductReview
            {
                ColorId = request.ColorId,
                ProductId = request.ProductId,
                SizeId = request.SizeId,
                Rating = request.Rating,
                ReviewCount = request.ReviewCount
            };

            this.context.VsproductReviews.Add(entity);

            await this.context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
