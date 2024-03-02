using System;
using System.Collections.Generic;

#nullable disable

namespace WebLibrary.Models
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
