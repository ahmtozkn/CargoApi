using Microsoft.AspNetCore.Mvc;

namespace Cargo.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
