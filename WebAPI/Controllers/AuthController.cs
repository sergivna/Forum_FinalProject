using WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private static readonly SignInModel _user = new SignInModel
        {
            UserName = "username",
            Password = "password"
        };

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        [HttpPost]
        [Route("sign-in")]
        public IActionResult SignIn([FromBody] SignInModel signInModel)
        {
            if (signInModel == null)
            {
                return BadRequest($"{nameof(signInModel)} must be passed");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isValid = _user.Password == signInModel.Password
                && _user.UserName == signInModel.UserName;

            if (!isValid)
            {
                return BadRequest("Wrong username or password");
            }

            string token = CreateToken(signInModel.UserName, out DateTime expiresAt);

            _httpContextAccessor.HttpContext.Response.Cookies.Append(JwtHelper.JwtCookieName, token,
                new CookieOptions
                {
                    HttpOnly = true,
                    Expires = expiresAt.AddDays(2),
                    SameSite = SameSiteMode.None,
                });

            return Ok (new { jwtToken = token });
        }

        private string CreateToken(string userName, out DateTime expiresAt)
        {
            DateTime issuedAt = DateTime.UtcNow;
            expiresAt = issuedAt + JwtHelper.TokenLifetTime;

            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userName)
            });


            SigningCredentials signingCredentials = JwtHelper.CreateCredentials();

            var token = tokenHandler
                .CreateJwtSecurityToken(
                    issuer: JwtHelper.Issuer,
                    audience: JwtHelper.Audience,
                    subject: claimsIdentity,
                    notBefore: issuedAt,
                    expires: expiresAt,
                    signingCredentials: signingCredentials);

            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}

