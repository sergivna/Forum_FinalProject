using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Status { get; set; }
        public string PhotoUrl { get; set; }

    }
}
