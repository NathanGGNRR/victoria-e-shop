//-----------------------------------------------------------------------
// <copyright file="DeleteVsColorCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsColors.Commands.DeleteVsColor
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Exceptions;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Delete color command handler.
    /// </summary>
    public class DeleteVsColorCommandHandler : IRequestHandler<DeleteVsColorCommand>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteVsColorCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public DeleteVsColorCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the delete request.
        /// </summary>
        /// <param name="request">Request to handle.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Unit value.</returns>
        public async Task<Unit> Handle(DeleteVsColorCommand request, CancellationToken cancellationToken)
        {
            var color = await this.context.Vscolors.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (color == null)
            {
                throw new NotFoundException(nameof(Vscolor), request.Id);
            }

            this.context.Vscolors.Remove(color);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}