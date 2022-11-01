//-----------------------------------------------------------------------
// <copyright file="IKeyCloakService.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Common.Interfaces
{
    using System.Threading.Tasks;
    using Application.Common.Models;

    /// <summary>
    /// The interface for the KeyCloakService.
    /// </summary>
    public interface IKeyCloakService
    {
        /// <summary>
        /// The Login.
        /// </summary>
        /// <param name="login">The login<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{KeyCloakToken}"/>.</returns>
        Task<KeyCloakToken> Login(string login, string password);
    }
}
