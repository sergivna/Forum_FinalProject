using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    class UserRegisterDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Photo { get; set; }

    }


}
