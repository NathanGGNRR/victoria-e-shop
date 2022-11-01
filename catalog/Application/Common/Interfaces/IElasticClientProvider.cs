//-----------------------------------------------------------------------
// <copyright file="IElasticClientProvider.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Interfaces
{
    using Nest;

    /// <summary>
    /// Interface for elastic client provider.
    /// </summary>
    public interface IElasticClientProvider
    {
        /// <summary>
        /// Gets the elastic client.
        /// </summary>
        /// <returns>An elastic client.</returns>
        IElasticClient Get();
    }
}