//-----------------------------------------------------------------------
// <copyright file="IIndexService.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Enums;

    /// <summary>
    /// Interface for index management.
    /// </summary>
    public interface IIndexService
    {
        /// <summary>
        /// Creates an index.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A boolean.</returns>
        Task<bool> CreateIndex(CancellationToken ct);

        /// <summary>
        /// Deletes an index.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A boolean.</returns>
        Task<bool> DeleteIndex(CancellationToken ct);
    }
}