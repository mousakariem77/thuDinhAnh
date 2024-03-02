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
   
    public class LearnerController : Controller
    {
         LearnerRepository LearnerRepository = null;
        public LearnerController() => LearnerRepository = new LearnerRepository();
        public IActionResult Index(string search = "", int page = 1, int pageSize = 2)
        {
            var learnerList = LearnerRepository.GetLearners();

            if (!string.IsNullOrEmpty(search))
            {
                learnerList = learnerList.Where(i => i.FirstName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 || i.LastName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            ViewBag.Search = search;
            var totalCount = learnerList.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            learnerList = learnerList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.Quantity = totalCount;
            ViewBag.CurrentPage = page;
            return View(learnerList);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Learner= LearnerRepository.GetLearnerByID(id.Value);
            if (Learner== null)
            {
                return NotFound();

            }
            return View(Learner);
        }
        //Get Learnercontroller/Create  
        public ActionResult Create() => View();
        //Post: Learnercontroller/ Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Learner Learner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LearnerRepository.InsertLearner(Learner);

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(Learner);
            }

        }
        //Get LearnersController/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Learner= LearnerRepository.GetLearnerByID(id.Value);
            if (Learner== null)
            {
                return NotFound();
            }
            return View(Learner);
        }
        //Post  Learnercontroller/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Learner Learner)
        {
            try
            {
                if (id != Learner.LearnerId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    LearnerRepository.UpdateLearner(Learner);
                }
                TempData["EditSuccess"] = true;
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
            var Learner= LearnerRepository.GetLearnerByID(id.Value);
            if (Learner== null)
            {
                return NotFound();
            }
            return View(Learner);
        }
        //Post Learnercontroller/delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                LearnerRepository.DeleteLearner(id);
                TempData["DeleteSuccess"] = true;
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