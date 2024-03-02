using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.DAO
{
    public class CourseDAO
    {
        private static CourseDAO instance = null;
        private static readonly object instanceLock = new object();
        public static CourseDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CourseDAO();

                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Course> GetCourselist()
        {
            var course = new List<Course>();
            try
            {
                using var context = new DBContext();
                course = context.Courses.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

                throw;
            }
            return course;
        }

        public Course GetCourseByID(int courseID)
        {
            Course course = null;
            try
            {
                using var context = new DBContext();
                course = context.Courses.SingleOrDefault(c => c.CourseId.Equals(courseID));

            }
            catch (System.Exception)
            {

                throw;
            }
            return course;
        }

        public void AddNew(Course course)
        {
            try
            {
                Course existingCourse = GetCourseByID(course.CourseId);
                if (existingCourse == null)
                {
                    using (var context = new DBContext())
                    {
                        context.Courses.Add(course);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The course already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Course course)
        {
            try
            {
                Course existingCourse = GetCourseByID(course.CourseId);
                if (existingCourse != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Courses.Update(course);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The course does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int courseID)
        {
            try
            {
                Course course = GetCourseByID(courseID);
                if (course != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Courses.Remove(course);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The course does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}