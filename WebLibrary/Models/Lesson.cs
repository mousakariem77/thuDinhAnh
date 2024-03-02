using System;
using System.Collections.Generic;

#nullable disable

namespace WebLibrary.Models
{
    public partial class Lesson
    {
        public int LessonId { get; set; }
        public int? ChapterId { get; set; }
        public string LessonName { get; set; }
        public string Description { get; set; }
        public int? PercentToPassed { get; set; }
        public bool? MustBeCompleted { get; set; }
        public string Content { get; set; }
        public int? Index { get; set; }
        public int? Type { get; set; }
        public int? Time { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}
