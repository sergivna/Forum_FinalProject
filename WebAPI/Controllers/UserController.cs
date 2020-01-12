using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private IWebHostEnvironment env;

        public UserController(IUserService userService, IWebHostEnvironment env)
        {
            this.userService = userService;
            this.env = env;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await userService.GetUser(currentId);

            if (user == null)
            {
                return BadRequest("User is not exsist");
            }

            return Ok(user);
        }

        [HttpPost("photo"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadPhoto(IFormFile filesData)
        {
            string fileName = Guid.NewGuid() + "_" + filesData.FileName;
            string path = env.WebRootPath + "\\Files\\" + fileName;

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await filesData.CopyToAsync(stream);
            }

            var currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await userService.SavePhoto(fileName, currentId);
            return Ok(new { fileName });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO)
        {
            if(userDTO.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (!await userService.UpdateUser(userDTO)) 
            {
                return BadRequest("Problem with updating user");
            };

            return Ok();
        }
    }
}