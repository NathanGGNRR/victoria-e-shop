//-----------------------------------------------------------------------
// <copyright file="AuthentificationController.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------

namespace KeyCloak.Controllers
{
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="AuthentificationController" />.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthentificationController : ControllerBase
    {
        /// <summary>
        /// Defines the _keyCloakService.
        /// </summary>
        private readonly IKeyCloakService _keyCloakService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthentificationController"/> class.
        /// </summary>
        /// <param name="keyCloakService">The keyCloakService<see cref="IKeyCloakService"/>.</param>
        public AuthentificationController(IKeyCloakService keyCloakService)
        {
            this._keyCloakService = keyCloakService;
        }

        /// <summary>
        /// The Login.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username != null && password != null)
            {
                var token = await this._keyCloakService.Login(username, password);
                if (token.Error == null)
                {
                    return this.Ok(token);
                }
            }

            return this.BadRequest();
        }
    }
}
