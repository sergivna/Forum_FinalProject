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
        //public Country Country { get; set; }
        //public virtual ICollection<Question> Questions { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
        public UserDTO()
        {
            //Publications = new List<PublicationDTO>();
            //Followers = new List<UserDTO>();
            //Following = new List<UserDTO>();
            //MessageHeaders = new List<MessageHeaderDTO>();
            //LikedPublications = new List<PublicationDTO>();
        }
    }
}
