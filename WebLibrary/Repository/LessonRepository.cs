using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public class LessonRepository : ILessonRepository
    {
        public Lesson GetLessonByID(int lessonId) => LessonDAO.Instance.GetLessonByID(lessonId);
        public IEnumerable<Lesson> GetLessons() => LessonDAO.Instance.GetLessonlist();
        public void InsertLesson(Lesson lesson) => LessonDAO.Instance.AddNew(lesson);
        public void DeleteLesson(int lessonId) => LessonDAO.Instance.Remove(lessonId);
        public void UpdateLesson(Lesson lesson) => LessonDAO.Instance.Update(lesson); 
    }
}