//-----------------------------------------------------------------------
// <copyright file="DeleteVsReviewCommand.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.VsReviews.Commands.DeleteReview
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MediatR;

    /// <summary>
    /// Review deletion command.
    /// </summary>
    public class DeleteVsReviewCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }
    }
}
