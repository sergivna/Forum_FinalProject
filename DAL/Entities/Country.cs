using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Country
    {
        public Country()
        {
            UserProfiles = new List<UserProfile>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
