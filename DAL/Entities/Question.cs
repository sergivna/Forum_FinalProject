using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Question
    {
        public Question()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; }
        public int UserId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateOfCreate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
