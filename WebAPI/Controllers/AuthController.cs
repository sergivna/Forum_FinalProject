using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using BLL.Interfaces;
using BLL.DTO;
using System.Threading.Tasks;


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

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody]UserLoginDTO userLogin)
        {
            var userFromDB = await authService.LogIn(userLogin);

            if (userFromDB == null)
            {
                return Unauthorized();
            }

            var token = await authService.GetToken(userFromDB);

            return Ok(new 
            { 
                token,
                userFromDB 
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO user)
        {
            var result = await authService.Register(user);
            if (result.Succeeded)
                return Ok();
            else
                return BadRequest(result.Errors);
        }
    }
}
