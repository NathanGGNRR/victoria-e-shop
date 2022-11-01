//-----------------------------------------------------------------------
// <copyright file="CreateVsCategoryCommandHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsCategories.Commands.CreateVsCategory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using MediatR;

    /// <summary>
    /// Category creation command handler.
    /// </summary>
    public class CreateVsCategoryCommandHandler : IRequestHandler<CreateVsCategoryCommand, int>
    {
        /// <summary>
        /// Database context used.
        /// </summary>
        private readonly IVictoriaContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVsCategoryCommandHandler"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public CreateVsCategoryCommandHandler(IVictoriaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles the creation request.
        /// </summary>
        /// <param name="request">Creation request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The id of the created category.</returns>
        public async Task<int> Handle(CreateVsCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Vscategory
            {
                CategoryName = request.CategoryName
            };

            this.context.Vscategories.Add(entity);

            await this.context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
