//-----------------------------------------------------------------------
// <copyright file="CreateVsColorCommand.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsColors.Commands.CreateVsColor
{
    using MediatR;

    /// <summary>
    /// Color creation command.
    /// </summary>
    public class CreateVsColorCommand : IRequest<int>
    {
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
