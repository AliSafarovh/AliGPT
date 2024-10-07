using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace TraversalProject.ViewComponents.Default
{
    public class _Testimonial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
