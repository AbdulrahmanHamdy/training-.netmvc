using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using progectmvc.Models;
using progectmvc.Repriditory;
using progectmvc.Viewmodel;

namespace progectmvc.Controllers
{
    public class EmployeeController : Controller
    {


        IDepartmentReprository departmenrep;
        IEmployeeReprository Employeerep;
        public EmployeeController(IEmployeeReprository empoo, IDepartmentReprository deptrepo) 
        {
            Employeerep = empoo; //new Employeerep();

            departmenrep = deptrepo; //new Departmenrep();
        }
        public IActionResult Details(int id)
        {
            string msg = "hello bitchs";
            int temp = 50;
            List  <string> branches = new List<string>();
            branches.Add("assiut");
            branches.Add("alex");
            branches.Add("cairo");
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["brch"] = branches;
            //ViewData.Model=emp
            Employee EmpMOdel = Employeerep.Getbyid(id);
            return View("Details", EmpMOdel);
        }
        /*
         public IActionResult DetailsVM(int id) 
         {

             Employee EmpMOdel = context.Employee.Include(e=>e.Department). FirstOrDefault(x => x.Id == id);
             List<string> branches = new List<string>();
             branches.Add("assiut");
             branches.Add("alex");
             branches.Add("cairo");
             EmpDEpetcolortempViewModel EmpVm= new EmpDEpetcolortempViewModel();
             EmpVm.EmpName = EmpMOdel.Name;
             EmpVm.DepName = EmpMOdel.Department.Name;
             EmpVm.Color="RED";
             EmpVm.Temp= 50;
             EmpVm.Branches = branches;  

             return View("DetailsVM", EmpVm);
         }
        */
        [Authorize]
        public IActionResult Index()
        {
            return View("Index", Employeerep.GetAll()); 
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee Empfromrequest)
        {
            if (Empfromrequest.Name != null)
            {
                Employee empfromdb = Employeerep.Getbyid(id); 
                if (empfromdb != null)
                {
                    empfromdb.Joptitle = Empfromrequest.Joptitle;
                    empfromdb.Salary = Empfromrequest.Salary;
                    empfromdb.Address = Empfromrequest.Address;
                    empfromdb.Image = Empfromrequest.Image;
                    empfromdb.Name = Empfromrequest.Name;
                    empfromdb.DepartmentId = Empfromrequest.DepartmentId;

                    Employeerep.save();
                    return RedirectToAction("Index");
                }
            }

            return View(Empfromrequest);
        }
        [HttpPost]
        public IActionResult New(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                Employeerep.Add(newEmployee);
                Employeerep.save();
                return RedirectToAction("Index");
            }
            return View(newEmployee);
        }
    }

}
