using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class QuestionToCreate
    {
        public string Header { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        //public DateTime DateOfCreate { get; set; }
    }
}
