using System;
using System.Collections.Generic;

#nullable disable

namespace WebLibrary.Models
{
    public partial class Instruct
    {
        public int InstructId { get; set; }
        public int? CourseId { get; set; }
        public int? InstructorId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
