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
        private IWebHostEnvironment _env;

        public UserController(IUserService userService, IWebHostEnvironment env)
        {
            this.userService = userService;
            _env = env;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await userService.GetUser(currentId);
            return Ok(user);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("photo")]
        public async Task<IActionResult> UploadPhoto(IFormFile filesData)
        {
            // var file = Request.Form.Files[0];

            string fileName = Guid.NewGuid() + "_" + filesData.FileName;
            string path = _env.WebRootPath + "\\Files\\" + fileName;

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await filesData.CopyToAsync(stream);
            }

            var currentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await userService.SavePhoto(fileName, currentId);
            return Ok(new { fileName });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO)
        {
            //isAuthorize
            await userService.UpdateUser(userDTO);
            return Ok();
        }
    }
}