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
        public IActionResult GetAll()
        {
            var result = _footballerImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getFootballerImageByFootballerId")]
        public IActionResult GetFootballerImageByFootballerId(int footballerId)
        {
            var result = _footballerImageService.GetFootballerImageByFootballerId(footballerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile[] files, [FromForm] FootballerImage footballerImage)
        {
            var result = _footballerImageService.AddCollective(files, footballerImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(FootballerImage footballerImage)
        {
            var result = _footballerImageService.Delete(footballerImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

    }
}
