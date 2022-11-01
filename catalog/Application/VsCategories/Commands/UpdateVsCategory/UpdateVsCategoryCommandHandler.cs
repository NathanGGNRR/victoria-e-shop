//-----------------------------------------------------------------------
// <copyright file="UpdateVsCategoryCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsCategories.Commands.UpdateVsCategory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Exceptions;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Handler for category update.
    /// </summary>
    public class UpdateVsCategoryCommandHandler : IRequestHandler<UpdateVsCategoryCommand>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVsCategoryCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public UpdateVsCategoryCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the update request.
        /// </summary>
        /// <param name="request">Request to handle.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The updated object.</returns>
        public async Task<Unit> Handle(UpdateVsCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.context.Vscategories.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Vscategory), request.Id);
            }

            entity.CategoryName = request.CategoryName;

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}