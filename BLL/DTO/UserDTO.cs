using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Status { get; set; }
        public string PhotoPath { get; set; }
        public CountryDTO Country { get; set; }
        public int CountryId {get;set;}
        public string UserName { get; set; }
        public List<string> Roles{ get; set; }

    }
}
