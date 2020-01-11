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
        public virtual UserProfile User { get; set; }
        public int  UserId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        public int? QuestionId { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}
