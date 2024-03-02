using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_Group3.Models;
using WebLibrary.DAO;
using WebLibrary.Models;
using WebLibrary.Repository;


namespace Project_Group3.Controllers
{
    public class InstructorController : Controller
    {
       IInstructorRepository instructorRepository = null;
        public InstructorController() => instructorRepository = new InstructorRepository();

        public IActionResult Index(string search = "", int page = 1, int pageSize = 2)
        {
            var instructorList = instructorRepository.GetInstructors();

            if (!string.IsNullOrEmpty(search))
            {
                instructorList = instructorList.Where(i => i.FirstName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 || i.LastName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            ViewBag.Search = search;
            var totalCount = instructorList.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            instructorList = instructorList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.Quantity = totalCount;
            ViewBag.CurrentPage = page;
            return View(instructorList);
        }

        public IActionResult Detail(int? id)
        {
            if(id == null){
                return NotFound();
            }
            var instructor = instructorRepository.GetInstructorByID(id.Value);
            if(instructor == null){
                return NotFound();
            }
            return View(instructor);
        }   
        
        [HttpPost]
        public IActionResult Next(int id)
        {
            var currentInstructor = instructorRepository.GetInstructorByID(id);
            var nextInstructor = instructorRepository.GetInstructors().FirstOrDefault(i => i.InstructorId > id);

            if (nextInstructor != null)
            {
                return RedirectToAction("Detail", new { id = nextInstructor.InstructorId });
            }
            else
            {
                var firstInstructor = instructorRepository.GetInstructors().FirstOrDefault();
                return RedirectToAction("Detail", new { id = firstInstructor.InstructorId });
            }
        }
        
        [HttpPost]
        public IActionResult Previous(int id)
        {
            var currentInstructor = instructorRepository.GetInstructorByID(id);

            // Tìm người giảng viên có ID nhỏ hơn ID hiện tại
            var previousInstructor = instructorRepository.GetInstructors().LastOrDefault(i => i.InstructorId < id);

            if (previousInstructor != null)
            {
                return RedirectToAction("Detail", new { id = previousInstructor.InstructorId });
            }
            else
            {
                // Nếu không có người giảng viên có ID nhỏ hơn, lấy người giảng viên cuối cùng
                var lastInstructor = instructorRepository.GetInstructors().LastOrDefault();
                return RedirectToAction("Detail", new { id = lastInstructor.InstructorId });
            }
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor instructor){
            try{
                if(ModelState.IsValid){
                    instructorRepository.InsertInstructor(instructor);
                }
                return RedirectToAction(nameof(Index));
            }catch(Exception ex){
                ViewBag.Message = ex.Message;
                return View(instructor);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instructor= instructorRepository.GetInstructorByID(id.Value);
            if (instructor== null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Instructor instructor)
        {
            try
            {
                if (id != instructor.InstructorId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    instructorRepository.UpdateInstructor(instructor);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();

            }
        }

        public IActionResult Delete(int? id)
        {
            if(id == null){
                return NotFound();
            }
            var instructor = instructorRepository.GetInstructorByID(id.Value);
            if(instructor == null){
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id){
            try{
                instructorRepository.DeleteInstructor(id);
                TempData["DeleteSuccess"] = true;
                return RedirectToAction(nameof(Index));
            }catch(Exception ex){
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public IActionResult Voucher()
        {
            // TODO: Your code here
            return View();
        }
        
    }
}