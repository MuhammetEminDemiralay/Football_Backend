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
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _clubImageService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest();
        }

        [HttpGet("getClubImageByClubId")]
        public async Task<IActionResult> GetImageByClubIdAsync(int clubId)
        {
            var result = await _clubImageService.GetImageByClubIdAsync(clubId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] IFormFile[] files, [FromForm] ClubImage clubImage)
        {
            var result = await _clubImageService.AddCollectiveAsync(files, clubImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(ClubImage clubImage)
        {
            var result = await _clubImageService.DeleteAsync(clubImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(IFormFile file, [FromForm] ClubImage clubImage)
        {
            var result = await _clubImageService.UpdateAsync(file, clubImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
