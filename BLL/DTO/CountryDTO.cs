using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
