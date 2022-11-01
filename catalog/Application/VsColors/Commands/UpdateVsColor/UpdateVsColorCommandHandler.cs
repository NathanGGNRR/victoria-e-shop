//-----------------------------------------------------------------------
// <copyright file="UpdateVsColorCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsColors.Commands.UpdateVsColor
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Exceptions;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Handler for color update.
    /// </summary>
    public class UpdateVsColorCommandHandler : IRequestHandler<UpdateVsColorCommand>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVsColorCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public UpdateVsColorCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the update request.
        /// </summary>
        /// <param name="request">Request to handle.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The updated object.</returns>
        public async Task<Unit> Handle(UpdateVsColorCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.context.Vscolors.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Vscolor), request.Id);
            }

            entity.ColorName = request.ColorName;
            entity.ColorCode = request.ColorCode;

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}