using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using progectmvc.Models;

namespace progectmvc.Controllers
{
    public class StudentController : Controller
    {
        Context context = new Context();
        [Authorize]
        public IActionResult Index()
        {
            List<Student> student = context.Student.ToList();
            return View("Index", student);
        }

        public IActionResult SaveAdd(Student newstd)  
        {
            if (ModelState.IsValid)
            {
                newstd.Id = 0;  // Ensure ID is not explicitly set
                context.Student.Add(newstd);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("SaveAdd");
        }
        public IActionResult Remove(int id)
        {
            var student = context.Student.Find(id);

            if (student == null)
            {
                return NotFound(); // Return 404 if department doesn't exist
            }

            context.Student.Remove(student);
            context.SaveChanges();

            return RedirectToAction("Index"); // Redirect to the department list
        }
    }
   }
