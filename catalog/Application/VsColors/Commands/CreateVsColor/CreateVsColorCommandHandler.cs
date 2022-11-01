//-----------------------------------------------------------------------
// <copyright file="CreateVsColorCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsColors.Commands.CreateVsColor
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;

    /// <summary>
    /// Color creation command handler.
    /// </summary>
    public class CreateVsColorCommandHandler : IRequestHandler<CreateVsColorCommand, int>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVsColorCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public CreateVsColorCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the creation request.
        /// </summary>
        /// <param name="request">Creation request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The id of the created color.</returns>
        public async Task<int> Handle(CreateVsColorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Vscolor
            {
                ColorName = request.ColorName,
                ColorCode = request.ColorCode
            };

            this.context.Vscolors.Add(entity);

            await this.context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
