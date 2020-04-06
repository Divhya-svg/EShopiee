// <copyright file="LoginController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.WebApi.Controllers
{
    using Kanini.ECommerce.EShopiee.BL.UserLogin;
    using Kanini.ECommerce.EShopiee.Model;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Login Controller with Authentication.
    /// </summary>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Constructor injection.
        /// </summary>
        private readonly IUserLoginRepo loginbl;
        private readonly IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="bl">From ILoginBl.</param>
        /// <param name="configuration">Configuration from Startup.</param>
        public LoginController(IUserLoginRepo bl, IConfiguration configuration)
        {
            this.loginbl = bl;
            this.config = configuration;
        }

        /// <summary>
        /// Method Authenticate.
        /// </summary>
        /// <param name="userParam">From UserDetails Model.</param>
        /// <returns>Authenticate and return View.</returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDetails userParam)
        {
            string secret = this.config.GetSection("Secret").ToString();

            this.loginbl.Secret = secret;
            var user = this.loginbl.Authenticate(userParam.EmailId, userParam.MobileNumber, userParam.Password, secret);
            if (user == null)
            {
                return this.BadRequest(new { message = "Username or password is incorrect" });
            }
            else
            {
                return this.Ok(user);
            }
        }

        /// <summary>
        /// GetUsers Method.
        /// </summary>
        /// <returns>View.</returns>
        [HttpGet("getusers")]
        public IActionResult GetAll()
        {
            var users = this.loginbl.GetAll();
            return this.Ok(users);
        }
    }
}