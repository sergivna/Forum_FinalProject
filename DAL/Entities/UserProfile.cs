using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class UserProfile
    {
        public UserProfile()
        {
            Questions = new List<Question>();
            Comments = new List<Comment>();
        }
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }       
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public string Status { get; set; }
        public string PhotoPath { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
