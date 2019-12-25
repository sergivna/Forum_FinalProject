using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        [ForeignKey("UserId")]
        public UserProfile User { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}
