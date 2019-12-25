using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IAuthService
    {
        UserDTO Register(UserRegisterDTO userRegister);
        UserDTO LogIn(UserLoginDTO userLogin);
        string GetToken(UserDTO user);
    }
}
