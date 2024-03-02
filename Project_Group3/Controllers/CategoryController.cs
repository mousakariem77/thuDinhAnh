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
  
    public class CategoryController : Controller
    {
      
        CategoryRepository categoryRepository = null;
        public CategoryController() => categoryRepository = new CategoryRepository();

        public ActionResult Index()
        {
            var Categorylist = categoryRepository.GetCategorys();
            return View(Categorylist);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Category= categoryRepository.GetCategoryByID(id.Value);
            if (Category== null)
            {
                return NotFound();

            }
            return View(Category);
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category Category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryRepository.InsertCategory(Category);

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(Category);
            }

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Category= categoryRepository.GetCategoryByID(id.Value);
            if (Category== null)
            {
                return NotFound();
            }
            return View(Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category Category)
        {
            try
            {
                if (id != Category.CategoryId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    categoryRepository.UpdateCategory(Category);
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
            var Category= categoryRepository.GetCategoryByID(id.Value);
            if (Category== null)
            {
                return NotFound();
            }
            return View(Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                categoryRepository.DeleteCategory(id);
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