using Business.Abstract;
using Entities.Concrete;
using Entities.Exceptions.Concrete;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }


        [HttpGet("yakala")]
        public async Task<IActionResult> GetYakala([FromQuery]CityParameters parameters)
        {
            var result = await _cityService.GetAllPaginationCity(parameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));

            if (result.metaData.TotalCount > 0)
            {
                return Ok(result.city);
            }

            return BadRequest();
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _cityService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(int id)
        {

            var result = await _cityService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(City city)
        {
            var result = await _cityService.AddAsync(city);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(City city)
        {
            var result = await _cityService.UpdateAsync(city);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(City city)
        {
            var result = await _cityService.DeleteAsync(city);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getCityByCountryId")]
        public async Task<IActionResult> GetCityByCountryıdAsync(int countryId)
        {
            var result = await _cityService.GetCityByCountryIdAsync(countryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, OPTIONS, HEAD");
            return Ok();
        }

        
    }
}
