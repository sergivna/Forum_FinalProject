using BLL.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(UserRegisterDTO userRegister);
        Task<UserDTO> LogIn(UserLoginDTO userLogin);
        Task<String> GetToken(UserDTO userDTO);
    }
}
