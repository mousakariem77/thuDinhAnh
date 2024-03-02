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
    public class HomeController : Controller
    {
        IInstructorRepository instructorRepository = null;
        ICourseRepository courseRepository = null;
        ICategoryRepository categoryRepository = null;
        IInstructRepository instructRepository = null;
        ILearnerRepository learnerRepository = null;
        IReviewRepository reviewRepository = null;
        ILessonRepository lessonRepository = null;
        IChapterRepository chapterRepository = null;
        public HomeController() {
            courseRepository = new CourseRepository();
            categoryRepository = new CategoryRepository();
            instructorRepository = new InstructorRepository();
            instructRepository = new InstructRepository();
            learnerRepository = new LearnerRepository();
            reviewRepository = new ReviewRepository();
            lessonRepository = new LessonRepository();
            chapterRepository = new ChapterRepository();
        } 
            

        public IActionResult Index()
        {

            var category = categoryRepository.GetCategorys();
            var categoryList = category.Take(8).ToList();
            var instructor = instructorRepository.GetInstructors();
            var instructorList = instructor.Take(4).ToList();

            return View(Tuple.Create(categoryList, instructorList));
        }

        public IActionResult About()
        {
            // TODO: Your code here
            return View();
        }

        public IActionResult Course()
        {
            var course = courseRepository.GetCourses();
            var category = categoryRepository.GetCategorys();
            var instruct = instructRepository.GetInstructs();
            var instructor = instructorRepository.GetInstructors();
            var courseList = course.ToList();
            var categoryList = category.ToList();
            var instructList = instruct.ToList();
            var instructorList = instructor.ToList();
            return View(Tuple.Create(courseList, categoryList, instructList, instructorList));
        }
        
        public IActionResult Contact()
        {
            // TODO: Your code here
            return View();
        }

        public IActionResult Profile(int? id)
        {
            id = 1;
            if(id == null){
                return NotFound();
            }
            var instructor = instructorRepository.GetInstructorByID(id.Value);
            var learner = learnerRepository.GetLearnerByID(id.Value);
                if(instructor == null){
                    return NotFound();
                }
                ViewBag.Role = "instructor";

            return View(instructor);
        }
        
        public IActionResult CourseDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instruct = instructRepository.GetInstructByID(id.Value);
            if (instruct== null)
            {
                return NotFound();
            }
            var courseId = TempData["CourseId"] as string;
            var course = courseRepository.GetCourses();
            var instructor = instructorRepository.GetInstructors();
            var review = reviewRepository.GetReviews();
            var learner = learnerRepository.GetLearners();
            var chapter = chapterRepository.GetChapters();
            var lesson = lessonRepository.GetLessons();
            
            var courseInfo = course.FirstOrDefault(c => c.CourseId == instruct.CourseId);
            var instructorInfo = instructor.FirstOrDefault(i => i.InstructorId == instruct.InstructorId);

            return View(Tuple.Create(courseInfo, instructorInfo, review, learner, chapter, lesson));
        }        

        public IActionResult Learning()
        {
            // TODO: Your code here
            return View();
        }
        
        public IActionResult CheckOut(int? id)
        {
            var learner = learnerRepository.GetLearnerByID(id.Value);

            return View(learner);
        }
        
    }
}
