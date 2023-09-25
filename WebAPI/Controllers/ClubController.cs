using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        IClubService _clubService;

        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _clubService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _clubService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(Club club)
        {
            var result = await _clubService.AddAsync(club);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(Club club)
        {
            var result = await _clubService.UpdateAsync(club);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(Club club)
        {
            var result = await _clubService.DeleteAsync(club);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("getClubsDetailByLeagueId")]
        public async Task<IActionResult> GetClubsByLeagueIdAsync(int leagueId)
        {
            var result = await _clubService.GetClubsDetailByLeagueIdAsync(leagueId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getClubDetailByClubId")]
        public async Task<IActionResult> GetClubDetailByClubIdAsync(int clubId)
        {
            var result = await _clubService.GetClubDetailByClubIdAsync(clubId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
