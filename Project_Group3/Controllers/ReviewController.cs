using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebLibrary.Models;
using WebLibrary.Repository;
using WebLibrary.DAO;

namespace Project_Group3.Controllers
{
    public class ReviewController : Controller
    {
        ReviewRepository reviewRepository = null;
        public ReviewController() => reviewRepository = new ReviewRepository();

        public ActionResult Index()
        {
            var Reviewlist = reviewRepository.GetReviews();
            return View(Reviewlist);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Review= reviewRepository.GetReviewByID(id.Value);
            if (Review== null)
            {
                return NotFound();

            }
            return View(Review);
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    review.LearnerId = 3; // Lấy giá trị LearnerID từ hidden field
                    review.CourseId = review.CourseId; // Lấy giá trị CourseID từ hidden field
                    reviewRepository.InsertReview(review);
                }

                TempData["CourseId"] = review.CourseId;
                return RedirectToAction("CourseDetail", "Home", new { id = review.CourseId });
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(review);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Review= reviewRepository.GetReviewByID(id.Value);
            if (Review== null)
            {
                return NotFound();
            }
            return View(Review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Review review)
        {
            try
            {
                if (id != review.ReviewId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    reviewRepository.UpdateReview(review);
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
            var Review = reviewRepository.GetReviewByID(id.Value);
            if (Review == null)
            {
                return NotFound();
            }
            return View(Review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                reviewRepository.DeleteReview(id);
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