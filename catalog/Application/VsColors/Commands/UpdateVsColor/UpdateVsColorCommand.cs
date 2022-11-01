//-----------------------------------------------------------------------
// <copyright file="UpdateVsColorCommand.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsColors.Commands.UpdateVsColor
{
    using MediatR;

    /// <summary>
    /// Color update command.
    /// </summary>
    public class UpdateVsColorCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ColorName.
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// Gets or sets the ColorCode.
        /// </summary>
        public string ColorCode { get; set; }
    }
}
