using FirstMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class ProductController : Controller
    {
        #region Result Tipleri
        #region IActionsResult

        // Butun Sehifeni Render Eder
        //public IActionResult GetProducts()
        //{
        //    return View();
        //    //retrun View(View Adi); 
        //}
        #endregion

        #region PartialViewResult
        //Sehife icindeki ilgili alani render eder
        //public PartialViewResult GetProducts()
        //{
        //    PartialViewResult result = PartialView();
        //    return result;
        //}
        #endregion

        #region JSONResult
        //public JsonResult GetProducts()
        //{
        //    //Json Formatinda deyer dondurur
        //    JsonResult result=Json(new Product
        //    {
        //        Id = 5,
        //        Name="Pen",
        //        stock=12
        //    });
        //    return result;

        //}

        #endregion

        #region EMptyResult
        //public EmptyResult GetProducts()
        //{
        //    //Bos deyer dondurer
        //    return new EmptyResult();
        //}
        #endregion

        #region ContentResult
        //public ContentResult GetProducts() 
        //{//Content deyer dondurur(String)
        //    ContentResult result = Content("SALAAm");
        //    return result;
        //}
        #endregion

        #region ActionResult
        //public ActionResult GetProducts()
        //{
        //    //Burun Resultlerin base tipidir.HErTip Deyer dondurur(empty,json,content ve s.)


        //}
        #endregion

        #endregion

       public IActionResult Index() 
        {
            X();
            return View();
        }

        [NonAction]
        public void X()
        {//NonAction metodlarda Business kodlar yazilir ve Action metodlarda cagirilir

        }
    }
}
