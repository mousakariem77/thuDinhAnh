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
    
    public class CourseController : Controller
    {
    
         CourseRepository coureseRepository = null;
        public CourseController() => coureseRepository = new CourseRepository();

        public IActionResult Index(string search = "", int page = 1, int pageSize = 5)
        {
            var courseList = coureseRepository.GetCourses();

            if (!string.IsNullOrEmpty(search))
            {
                courseList = courseList.Where(i => i.CourseName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            ViewBag.Search = search;
            var totalCount = courseList.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            courseList = courseList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.Quantity = totalCount;
            ViewBag.CurrentPage = page;
            return View(courseList);
        }

        public IActionResult CourseList()
        {
            var courseList = coureseRepository.GetCourses();
            return View(courseList);
        }
        
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Course= coureseRepository.GetCourseByID(id.Value);
            if (Course== null)
            {
                return NotFound();

            }
            return View(Course);
        }
  
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    coureseRepository.InsertCourse(course);

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(course);
            }

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Course= coureseRepository.GetCourseByID(id.Value);
            if (Course== null)
            {
                return NotFound();
            }
            return View(Course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course course)
        {
            try
            {
                if (id != course.CourseId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    coureseRepository.UpdateCourse(course);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();

            }
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course= coureseRepository.GetCourseByID(id.Value);
            if (course== null)
            {
                return NotFound();
            }
            return View(course);
        }
        //Post Learnercontroller/delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                coureseRepository.DeleteCourse(id);
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