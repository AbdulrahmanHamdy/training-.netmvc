 using Microsoft.AspNetCore.Mvc;
using progectmvc.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace progectmvc.Controllers
{
    public class HomeController : Controller
    {

        //method public
        public ActionResult ShowMsg()
        {
            return View("View1");
        }
        public ActionResult ShowMix(int id) 
        {
            if (id % 2 == 0)
            {
                return View("View1");
            }
            else
                return Content("hello");
        }








        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
