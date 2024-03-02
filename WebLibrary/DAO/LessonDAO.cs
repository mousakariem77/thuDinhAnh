using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.DAO
{
    public class LessonDAO
    {
        private static LessonDAO instance = null;
        private static readonly object instanceLock = new object();
        public static LessonDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new LessonDAO();

                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Lesson> GetLessonlist()
        {
            var lesson = new List<Lesson>();
            try
            {
                using var context = new DBContext();
                lesson = context.Lessons.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

                throw;
            }
            return lesson;
        }

        public Lesson GetLessonByID(int lessonID)
        {
            Lesson lesson = null;
            try
            {
                using var context = new DBContext();
                lesson = context.Lessons.SingleOrDefault(c => c.LessonId.Equals(lessonID));

            }
            catch (System.Exception)
            {

                throw;
            }
            return lesson;
        }

        public void AddNew(Lesson lesson)
        {
            try
            {
                Lesson existingLesson = GetLessonByID(lesson.LessonId);
                if (existingLesson == null)
                {
                    using (var context = new DBContext())
                    {
                        context.Lessons.Add(lesson);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The lesson already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Lesson lesson)
        {
            try
            {
                Lesson existingLesson = GetLessonByID(lesson.LessonId);
                if (existingLesson != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Lessons.Update(lesson);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The lesson does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int lessonID)
        {
            try
            {
                Lesson lesson = GetLessonByID(lessonID);
                if (lesson != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Lessons.Remove(lesson);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The lesson does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}