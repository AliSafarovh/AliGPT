using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.Comments
{
    public class _AddComment:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
