using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.MemberDashboard
{
    public class _PlatformSettings:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
