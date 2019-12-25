using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Category
    {
        public Category()
        {
            Questions = new List<Question>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descriptios { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
