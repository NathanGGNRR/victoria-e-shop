//-----------------------------------------------------------------------
// <copyright file="KeyCloakToken.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------

namespace Application.Common.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="KeyCloakToken" />.
    /// </summary>
    public class KeyCloakToken
    {
        /// <summary>
        /// Gets or sets the AccessToken.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the ExpiresIn.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the RefreshExpiresIn.
        /// </summary>
        [JsonProperty("refresh_expires_in")]
        public int RefreshExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the RefreshToken.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the TokenType.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the NotBeforePolicy.
        /// </summary>
        [JsonProperty("not-before-policy")]
        public int NotBeforePolicy { get; set; }

        /// <summary>
        /// Gets or sets the SessionState.
        /// </summary>
        [JsonProperty("session_state")]
        public string SessionState { get; set; }

        /// <summary>
        /// Gets or sets the Scope.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the Error.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the ErrorDescription.
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
