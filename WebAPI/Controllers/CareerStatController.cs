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
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _careerStatService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _careerStatService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(CareerStat careerStat)
        {
            var result = await _careerStatService.AddAsync(careerStat);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(CareerStat careerStat)
        {
            var result = await _careerStatService.UpdateAsync(careerStat);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(CareerStat careerStat)
        {
            var result = await _careerStatService.DeleteAsync(careerStat);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


    }
}
