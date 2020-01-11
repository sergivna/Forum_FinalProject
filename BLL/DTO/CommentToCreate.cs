using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CommentToCreate
    {
        public string Message { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public DateTime DateOfCreate { get; set;}
    }
}
