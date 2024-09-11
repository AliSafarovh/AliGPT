using Microsoft.AspNetCore.Mvc;

namespace MVC_Proje.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
