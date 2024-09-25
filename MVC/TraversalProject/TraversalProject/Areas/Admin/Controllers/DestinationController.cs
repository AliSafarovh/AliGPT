using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/[controller]/[action]")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destinationManager.Add(destination);
            return Redirect("/Admin/Destination/Index");

        }

        public IActionResult DeleteDestination(int id)
        {
            var values=destinationManager.GetByID(id);
            destinationManager.Delete(values);
            return Redirect("/Admin/Destination/Index");

        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = destinationManager.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            destinationManager.Update(destination);
            return Redirect("/Admin/Destination/Index");
        }
    }
}
