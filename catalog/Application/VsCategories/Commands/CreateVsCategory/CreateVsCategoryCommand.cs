//-----------------------------------------------------------------------
// <copyright file="CreateVsCategoryCommand.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsCategories.Commands.CreateVsCategory
{
    using MediatR;

    /// <summary>
    /// Color creation command.
    /// </summary>
    public class CreateVsCategoryCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the CategoryName.
        /// </summary>
        public string CategoryName { get; set; }
    }
}
