using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using progectmvc.Filters;

namespace progectmvc.Controllers
{
    public class FiltterController : Controller
    {
        //[HandelError]
        //[Authorize]
        public IActionResult Index()
        {
            throw new Exception("Exception Fr index");
        }
    }
}
