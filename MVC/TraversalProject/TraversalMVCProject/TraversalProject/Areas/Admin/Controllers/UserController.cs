using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IAppUserService _appUserService;
        IReservationService _reservationService;
        public UserController(IAppUserService appUserService,IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }
        public IActionResult Index()
        {
            var values = _appUserService.GetList();    
            return View(values);
        }
        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.GetByID(id);
            _appUserService.Delete(values);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult EditUser(int id)
        {
            var values=_appUserService.GetByID(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult UpdateUser(AppUser appUser)
        {
            _appUserService.Update(appUser);
            return RedirectToAction("Index");

        }
        public IActionResult CommentUser(int id)
        {
            _appUserService.GetList();
            return View();
        }
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}
