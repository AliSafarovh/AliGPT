using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.Comments
{
    public class _CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
