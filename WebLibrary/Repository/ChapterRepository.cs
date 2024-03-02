using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public class ChapterRepository : IChapterRepository
    {
        public Chapter GetChapterByID(int chapterId) => ChapterDAO.Instance.GetChapterByID(chapterId);
        public IEnumerable<Chapter> GetChapters() => ChapterDAO.Instance.GetChapterlist();
        public void InsertChapter(Chapter chapter) => ChapterDAO.Instance.AddNew(chapter);
        public void DeleteChapter(int chapterId) => ChapterDAO.Instance.Remove(chapterId);
        public void UpdateChapter(Chapter chapter) => ChapterDAO.Instance.Update(chapter);
    }
}