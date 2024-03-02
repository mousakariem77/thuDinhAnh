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
   
    public class LessonController : Controller
    {
       
         LessonRepository lessonRepository = null;
        public LessonController() => lessonRepository = new LessonRepository();
        //Get LearnerController
        public ActionResult Index()
        {
            var Lessonlist = lessonRepository.GetLessons();
            return View(Lessonlist);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Lesson= lessonRepository.GetLessonByID(id.Value);
            if (Lesson== null)
            {
                return NotFound();

            }
            return View(Lesson);
        }
        //Get Learnercontroller/Create  
        public ActionResult Create() => View();
        //Post: Learnercontroller/ Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lesson Lesson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lessonRepository.InsertLesson(Lesson);

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(Lesson);
            }

        }
        //Get CoureseController/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Lesson= lessonRepository.GetLessonByID(id.Value);
            if (Lesson== null)
            {
                return NotFound();
            }
            return View(Lesson);
        }
        //Post  Learnercontroller/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Lesson Lesson)
        {
            try
            {
                if (id != Lesson.LessonId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    lessonRepository.UpdateLesson(Lesson);
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
            var Lesson= lessonRepository.GetLessonByID(id.Value);
            if (Lesson== null)
            {
                return NotFound();
            }
            return View(Lesson);
        }
        //Post Learnercontroller/delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                lessonRepository.DeleteLesson(id);
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