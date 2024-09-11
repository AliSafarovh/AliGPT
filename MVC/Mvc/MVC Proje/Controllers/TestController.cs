using Microsoft.AspNetCore.Mvc;
namespace MVC_Proje.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var values = 12;
            return View(values);
            
        }
    }
}
