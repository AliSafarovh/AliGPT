using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TraversalProject.Areas.Admin.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task <IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5094/api/Visitor");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddVisitor() 
        {
         return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Modeldə səhv varsa səhifəni yenidən göstərir.
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5094/api/Visitor", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/VisitorApi/Index/");
            }

            return View(model);
        }
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5094/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/VisitorApi/Index/");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5094/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateVisitor(VisitorViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5094/api/Visitor", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/VisitorApi/Index/");
            }
            return View();
        }


    }
}
