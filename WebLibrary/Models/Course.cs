using System;
using System.Collections.Generic;

#nullable disable

namespace WebLibrary.Models
{
    public partial class Course
    {
        public Course()
        {
            Chapters = new HashSet<Chapter>();
            Instructs = new HashSet<Instruct>();
            Reviews = new HashSet<Review>();
        }

        public int CourseId { get; set; }
        public int? CategoryId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int? TotalTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Instruct> Instructs { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
