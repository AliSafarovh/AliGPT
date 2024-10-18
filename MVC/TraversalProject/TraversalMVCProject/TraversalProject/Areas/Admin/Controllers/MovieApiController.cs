using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalProject.Areas.Admin.Models;
namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class MovieApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> apimovie = new List<ApiMovieViewModel>();
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "8432e75ebemsha566c169cb0cbf2p1e8470jsne10c380c1d50" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apimovie=JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(apimovie);
            }
        }
    }
}
