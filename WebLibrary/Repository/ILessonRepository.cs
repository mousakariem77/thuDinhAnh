using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public interface ILessonRepository
    {
        IEnumerable<Lesson> GetLessons();
        Lesson GetLessonByID(int lessonId);
        void InsertLesson(Lesson lesson);
        void DeleteLesson(int lessonId);
        void UpdateLesson(Lesson lesson);
    }
}