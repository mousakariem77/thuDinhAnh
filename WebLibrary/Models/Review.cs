using System;
using System.Collections.Generic;

#nullable disable

namespace WebLibrary.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? CourseId { get; set; }
        public int? LearnerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Learner Learner { get; set; }
    }
}
