using Microsoft.AspNetCore.Mvc;

namespace Pfeapp2.Controllers
{
    public class Home1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
