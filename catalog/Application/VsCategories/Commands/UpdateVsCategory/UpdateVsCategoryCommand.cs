//-----------------------------------------------------------------------
// <copyright file="UpdateVsCategoryCommand.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsCategories.Commands.UpdateVsCategory
{
    using MediatR;

    /// <summary>
    /// Category update command.
    /// </summary>
    public class UpdateVsCategoryCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName.
        /// </summary>
        public string CategoryName { get; set; }
    }
}
