using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubImageController : ControllerBase
    {
        IClubImageService _clubImageService;

        public ClubImageController(IClubImageService clubImageService)
        {
            _clubImageService = clubImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _clubImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getLeagueImagesByLeagueId")]
        public IActionResult GetImageByLeagueId(int clubId)
        {
            var result = _clubImageService.GetImageByClubId(clubId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile[] files, [FromForm] ClubImage clubImage)
        {
            var result = _clubImageService.AddCollective(files, clubImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ClubImage clubImage)
        {
            var result = _clubImageService.Delete(clubImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

    }
}
