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
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _countryImageService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getCountryImageByCountryId")]
        public async Task<IActionResult> GetImageByCountryIdAsync(int countryId)
        {
            var result = await _countryImageService.GetImageByCountryIdAsync(countryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] IFormFile[] files, [FromForm] CountryImage countryImage)
        {
            var result = await _countryImageService.AddCollectiveAsync(files, countryImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(CountryImage countryImage)
        {
            var result = await _countryImageService.DeleteAsync(countryImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(IFormFile file, [FromForm] CountryImage countryImage)
        {
            var result = await _countryImageService.UpdateAsync(file, countryImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
