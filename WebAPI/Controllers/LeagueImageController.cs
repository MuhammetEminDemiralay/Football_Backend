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
        public IActionResult GetAll()
        {
            var result = _leagueImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getLeagueImagesByLeagueId")]
        public IActionResult GetImageByCountryId(int leagueId)
        {
            var result = _leagueImageService.GetLeagueImageByLeagueId(leagueId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile[] files, [FromForm] LeagueImage leagueImage)
        {
            var result = _leagueImageService.AddCollective(files, leagueImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(LeagueImage leagueImage)
        {
            var result = _leagueImageService.Delete(leagueImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

    }
}
