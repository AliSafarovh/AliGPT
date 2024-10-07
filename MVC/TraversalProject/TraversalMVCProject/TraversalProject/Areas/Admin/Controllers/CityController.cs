using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalProject.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.GetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            try
            {
                destination.Status = true;
                _destinationService.Add(destination);
                var values = JsonConvert.SerializeObject(destination);
                return Json(values);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Xəta: {ex.Message}");
            }
        }

        public IActionResult GetById(int DestinationId)
        {
            var values = _destinationService.GetByID(DestinationId);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.GetByID(id);
            _destinationService.Delete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            var existingDestination = _destinationService.GetByID(destination.DestinationId);

            if (existingDestination != null)
            {
                // Yalnız dolu dəyərləri yeniləyin
                existingDestination.City = destination.City ?? existingDestination.City;
                existingDestination.Price = destination.Price != 0 ? destination.Price : existingDestination.Price;
                existingDestination.Description = destination.Description ?? existingDestination.Description;
                existingDestination.Status = destination.Status; // Status mütləq yenilənəcək, default true

                _destinationService.Update(existingDestination);
                var v = JsonConvert.SerializeObject(existingDestination);
                return Json(v);
            }

            return NotFound("Şəhər tapılmadı.");
        }


    }
}
