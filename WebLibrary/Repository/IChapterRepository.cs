using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public interface IChapterRepository
    {
        IEnumerable<Chapter> GetChapters();
        Chapter GetChapterByID(int chapterId);
        void InsertChapter(Chapter chapter);
        void DeleteChapter(int chapterId);
        void UpdateChapter(Chapter chapter);
    } 
}