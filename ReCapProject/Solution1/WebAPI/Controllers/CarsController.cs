using Business.Abstract;
using Core.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = _carService.GetAll();
            {
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }

        }

        [HttpPost("add")]
        public IActionResult Post(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Put(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete]

       public IActionResult Delete(Car car)
        {
            var result=_carService.Delete(car);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }

}
