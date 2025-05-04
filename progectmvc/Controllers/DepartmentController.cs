using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using progectmvc.Models;
using progectmvc.Repriditory;

namespace progectmvc.Controllers
{


    public class DepartmentController : Controller
    {

        IDepartmentReprository departmenrep;
       
        public DepartmentController(IDepartmentReprository deptrepo)
        {


            departmenrep = deptrepo;//new Departmenrep();
        }
        [Authorize]
        public IActionResult Index()
        {
            List<Department> Dlist = departmenrep.GetAll();
            return View("Index", Dlist);
        }

        public IActionResult SaveAdd(Department newDept)
        {
            if (!string.IsNullOrWhiteSpace(newDept.Name))
            {
                newDept.Id = 0;  // Ensure ID is not explicitly set
                    departmenrep.Add(newDept);
                departmenrep.save();
                return RedirectToAction("Index");
            }

            return View("SaveAdd");
        }
        public IActionResult Remove(int id)
        {
            var department = departmenrep.Getbyid(id);

            if (department == null)
            {
                return NotFound(); // Return 404 if department doesn't exist
            }

          departmenrep.delete(id);
            departmenrep.save();

            return RedirectToAction("Index"); // Redirect to the department list
        }

        // GET: Department/Edit/{id}
        public IActionResult Edit(int id)
        {
            var department = departmenrep.Getbyid(id);

            if (department == null)
            {
                return NotFound(); // Return 404 if department doesn't exist
            }

            return View(department); // Pass the department to the view
        }

        // POST: Department/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest(); // Ensure the ID matches
            }

            if (ModelState.IsValid)
            {
               departmenrep.update(department);    
                departmenrep.save();
                return RedirectToAction("Index"); // Redirect to the department list
            }

            return View(department); // If validation fails, return to the edit form
        }


    }
}
