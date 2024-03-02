using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        Course GetCourseByID(int courseId);
        void InsertCourse(Course course);
        void DeleteCourse(int courseId);
        void UpdateCourse(Course course);
    }
}