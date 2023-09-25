using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueImageController : ControllerBase
    {
        ILeagueImageService _leagueImageService;

        public LeagueImageController(ILeagueImageService leagueImageService)
        {
            _leagueImageService = leagueImageService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _leagueImageService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getLeagueImagesByLeagueId")]
        public async Task<IActionResult> GetImageByCountryIdAsync(int leagueId)
        {
            var result = await _leagueImageService.GetLeagueImageByLeagueIdAsync(leagueId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] IFormFile[] files, [FromForm] LeagueImage leagueImage)
        {
            var result = await _leagueImageService.AddCollectiveAsync(files, leagueImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(LeagueImage leagueImage)
        {
            var result = await _leagueImageService.DeleteAsync(leagueImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

    }
}
