using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace TraversalProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ILogger <DefaultController>_logger;
        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            DateTime d = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            _logger.LogInformation (d + "Index metodu calisdi");
            return View();
        }
        public IActionResult Test()
        {
            _logger.LogInformation("Test metodu calisdi");
            _logger.LogError("Error Logu cagirildi");
            return View();
        }
    }
}
