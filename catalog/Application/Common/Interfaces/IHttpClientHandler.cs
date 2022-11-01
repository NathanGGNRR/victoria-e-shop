//-----------------------------------------------------------------------
// <copyright file="IHttpClientHandler.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Enums;

    /// <summary>
    /// The interface for the HttpClientHandler.
    /// </summary>
    public interface IHttpClientHandler
    {
        /// <summary>
        /// Method to generate a API request.
        /// </summary>
        /// <typeparam name="TRequest">The request with the potential parameters.</typeparam>
        /// <typeparam name="TResult">The result of the request</typeparam>
        /// <param name="clientApi">The API.</param>
        /// <param name="url">The url.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="method">The type of the method.</param>
        /// <param name="requestEntity">The request entity.</param>
        /// <returns>Return a TResult object.</returns>
        Task<TResult> GenericRequest<TRequest, TResult>(
            string clientApi, 
            string url,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class;
    }
}