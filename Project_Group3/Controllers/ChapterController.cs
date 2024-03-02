using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebLibrary.Models;
using WebLibrary.Repository;
namespace Project_Group3.Controllers
{

    public class ChapterController : Controller
    {

         ChapterRepository chapterRepository = null;
        public ChapterController() => chapterRepository = new ChapterRepository();
        //Get LearnerController
        public ActionResult Index()
        {
            var Chapterlist = chapterRepository.GetChapters();
            return View(Chapterlist);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Chapter= chapterRepository.GetChapterByID(id.Value);
            if (Chapter== null)
            {
                return NotFound();

            }
            return View(Chapter);
        }
        //Get Learnercontroller/Create  
        public ActionResult Create() => View();
        //Post: Learnercontroller/ Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chapter Chapter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chapterRepository.InsertChapter(Chapter);

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(Chapter);
            }

        }
        //Get CoureseController/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Chapter= chapterRepository.GetChapterByID(id.Value);
            if (Chapter== null)
            {
                return NotFound();
            }
            return View(Chapter);
        }
        //Post  Learnercontroller/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Chapter Chapter)
        {
            try
            {
                if (id != Chapter.ChapterId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    chapterRepository.UpdateChapter(Chapter);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();

            }
        }
        //Get LearnerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Chapter= chapterRepository.GetChapterByID(id.Value);
            if (Chapter== null)
            {
                return NotFound();
            }
            return View(Chapter);
        }
        //Post Learnercontroller/delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                chapterRepository.DeleteChapter(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)

            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }
    }
}