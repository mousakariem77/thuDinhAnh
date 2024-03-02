using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.DAO
{
    public class ChapterDAO
    {
        private static ChapterDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ChapterDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ChapterDAO();

                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Chapter> GetChapterlist()
        {
            var chapter = new List<Chapter>();
            try
            {
                using var context = new DBContext();
                chapter = context.Chapters.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

                throw;
            }
            return chapter;
        }

        public Chapter GetChapterByID(int chapterID)
        {
            Chapter chapter = null;
            try
            { 
                using var context = new DBContext();
                chapter = context.Chapters.SingleOrDefault(c => c.ChapterId.Equals(chapterID));

            }
            catch (System.Exception)
            {

                throw;
            }
            return chapter;
        }

        public void AddNew(Chapter chapter)
        {
            try
            {
                Chapter existingChapter = GetChapterByID(chapter.ChapterId);
                if (existingChapter == null)
                {
                    using (var context = new DBContext())
                    {
                        context.Chapters.Add(chapter);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The chapter already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Chapter chapter)
        {
            try
            {
                Chapter existingChapter = GetChapterByID(chapter.ChapterId);
                if (existingChapter != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Chapters.Update(chapter);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The chapter does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int chapterID)
        {
            try
            {
                Chapter chapter = GetChapterByID(chapterID);
                if (chapter != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Chapters.Remove(chapter);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The chapter does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}