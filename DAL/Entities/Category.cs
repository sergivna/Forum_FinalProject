using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Category
    {
        public Category()
        {
            Questions = new List<Question>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptios { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
