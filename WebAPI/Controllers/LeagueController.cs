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
        public IActionResult GetAll()
        {
            var result = _leagueService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _leagueService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(League league)
        {
            var result = _leagueService.Add(league);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(League league)
        {
            var result = _leagueService.Update(league);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(League league)
        {
            var result = _leagueService.Delete(league);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getLeaguesDetailbyCountryId")]
        public IActionResult GetLeaguesbyCountryId(int countryId)
        {
            var result = _leagueService.GetLeaguesbyCountryId(countryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }





    }
}
