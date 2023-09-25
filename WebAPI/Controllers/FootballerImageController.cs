using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballerImageController : ControllerBase
    {
        IFootballerImageService _footballerImageService;

        public FootballerImageController(IFootballerImageService footballerImageService)
        {
            _footballerImageService = footballerImageService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _footballerImageService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getFootballerImageByFootballerId")]
        public async Task<IActionResult> GetFootballerImageByFootballerIdAsync(int footballerId)
        {
            var result = await _footballerImageService.GetFootballerImageByFootballerIdAsync(footballerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] IFormFile[] files, [FromForm] FootballerImage footballerImage)
        {
            var result = await _footballerImageService.AddCollectiveAsync(files, footballerImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(FootballerImage footballerImage)
        {
            var result = await _footballerImageService.DeleteAsync(footballerImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

    }
}
