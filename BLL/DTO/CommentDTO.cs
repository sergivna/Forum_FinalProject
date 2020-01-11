using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual QuestionDTO Question { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}
