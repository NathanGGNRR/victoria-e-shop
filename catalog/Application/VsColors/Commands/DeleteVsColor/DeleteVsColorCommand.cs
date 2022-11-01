//-----------------------------------------------------------------------
// <copyright file="DeleteVsColorCommand.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsColors.Commands.DeleteVsColor
{
    using MediatR;

    /// <summary>
    /// Color deletion command.
    /// </summary>
    public class DeleteVsColorCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }
    }
}
