using Microsoft.AspNetCore.Mvc;

namespace progectmvc.Controllers
{
    public class BindController : Controller
    {
        public IActionResult testPrimitive(string name,int age)
        {
            return Content($"{name}\t{age}");
        }
    }
}
