using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public DateTime DateOfCreate { get; set; }
        //public virtual ICollection<CommentDTO> Comments { get; set; }
    }
}