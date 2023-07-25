using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerStatController : ControllerBase
    {
        ICareerStatService _careerStatService;

        public CareerStatController(ICareerStatService careerStatService)
        {
            _careerStatService = careerStatService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _careerStatService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _careerStatService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(CareerStat careerStat)
        {
            var result = _careerStatService.Add(careerStat);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(CareerStat careerStat)
        {
            var result = _careerStatService.Update(careerStat);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(CareerStat careerStat)
        {
            var result = _careerStatService.Delete(careerStat);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


    }
}
