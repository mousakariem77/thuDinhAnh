using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public Course GetCourseByID(int courseId) => CourseDAO.Instance.GetCourseByID(courseId);
        public IEnumerable<Course> GetCourses() => CourseDAO.Instance.GetCourselist();
        public void InsertCourse(Course course) => CourseDAO.Instance.AddNew(course);
        public void DeleteCourse(int courseId) => CourseDAO.Instance.Remove(courseId);
        public void UpdateCourse(Course course) => CourseDAO.Instance.Update(course); 
    }
}