using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _leagueService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        //[HttpGet("get")]
        //public async Task<IActionResult> GetAsync(int id)
        //{
        //    var result = await _leagueService.GetAsync(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest();
        //}

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(League league)
        {
            var result = await _leagueService.AddAsync(league);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(League league)
        {
            var result = await _leagueService.UpdateAsync(league);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(League league)
        {
            var result = await _leagueService.DeleteAsync(league);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getLeaguesDetailbyCountryId")]
        public async Task<IActionResult> GetLeaguesbyCountryIdAsync(int countryId)
        {
            var result = await _leagueService.GetLeaguesbyCountryIdAsync(countryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("getLeagueDetailByLeagueId")]
        public async Task<IActionResult> GetLegaueDetailByLeagueIdAsync(int leagueId)
        {
            var result = await _leagueService.GetLegaueDetailByLeagueIdAsync(leagueId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }



    }
}
