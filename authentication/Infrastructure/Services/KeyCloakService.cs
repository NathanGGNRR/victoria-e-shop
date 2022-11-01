//-----------------------------------------------------------------------
// <copyright file="KeyCloakService.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------

namespace Infrastructure.Keycloak
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.Common.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="KeyCloakService" />.
    /// </summary>
    internal class KeyCloakService : IKeyCloakService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyCloakService"/> class.
        /// </summary>
        public KeyCloakService()
        {
        }

        /// <summary>
        /// The Login.
        /// </summary>
        /// <param name="login">The login<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{KeyCloakToken}"/>.</returns>
        public async Task<KeyCloakToken> Login(string login, string password)
        {
            using (var httpClient = new HttpClient())
            {
                string apiUrl = $"{Environment.GetEnvironmentVariable("KeyCloakUrl")}/protocol/openid-connect/token";
                var parameters = new Dictionary<string, string>
                {
                    { "client_id", Environment.GetEnvironmentVariable("KeyCloakClientID") },
                    { "username", login },
                    { "password", password },
                    { "grant_type", "password" },
                };
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = new FormUrlEncodedContent(parameters)
                };
                var response = await httpClient.SendAsync(request);
                var contentResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<KeyCloakToken>(contentResponse);
            }
        }
    }
}
