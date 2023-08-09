using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryImageController : ControllerBase
    {
        ICountryImageService _countryImageService;

        public CountryImageController(ICountryImageService countryImageService)
        {
            _countryImageService = countryImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _countryImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getImageByCountryId")]
        public IActionResult GetImageByCountryId(int countryId)
        {
            var result = _countryImageService.GetImageByCountryId(countryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile[] files, [FromForm] CountryImage countryImage)
        {
            var result = _countryImageService.AddCollective(files, countryImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CountryImage countryImage)
        {
            var result = _countryImageService.Delete(countryImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

    }
}
