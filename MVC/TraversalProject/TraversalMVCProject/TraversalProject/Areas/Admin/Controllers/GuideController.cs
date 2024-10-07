using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        IGuideService _guideService;
        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        public IActionResult Index()
        {
            var values = _guideService.GetList(); 
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);
            if (result.IsValid)
            {
                _guideService.Add(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values =_guideService.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.Update(guide);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToTrue(int id)
        {
            _guideService.ChangeToTrueByGuide(id);
            return Redirect("/Admin/Guide/Index");
        }
        public IActionResult ChangeToFalse(int id)
        {
            _guideService.ChangeToFalseByGuide(id);
            return Redirect("/Admin/Guide/Index");
        }
    }
}
