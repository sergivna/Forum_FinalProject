using WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.DTO;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAuthService authService;

        public AuthController(IHttpContextAccessor httpContextAccessor, IAuthService authService)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            this.authService = authService;
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> SignIn([FromBody]UserLoginDTO userLogin)
        {
            if (userLogin == null)
            {
                return BadRequest($"{nameof(userLogin)} must be passed");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDb = await authService.LogIn(userLogin);

            if (userDb == null)
            {
                return Unauthorized();
            }

            var token = await authService.GetToken(userDb);


            httpContextAccessor.HttpContext.Response.Cookies.Append(JwtHelper.JwtCookieName, token,
                new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddDays(2),
                    SameSite = SameSiteMode.None,
                });

            //return Ok(new { jwtToken = token });
            return Ok(new { token, userDb });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegisterDTO user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authService.Register(user);
            if(result.Succeeded)
            return Ok();
            else
                return BadRequest(result.Errors);
        }

    }
}
