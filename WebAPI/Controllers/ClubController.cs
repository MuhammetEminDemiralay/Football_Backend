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
        public IActionResult GetAll()
        {
            var result = _clubService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _clubService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Club club)
        {
            var result = _clubService.Add(club);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Club club)
        {
            var result = _clubService.Update(club);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Club club)
        {
            var result = _clubService.Delete(club);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("getClubsDetailByLeagueId")]
        public IActionResult GetClubsByLeagueId(int leagueId)
        {
            var result = _clubService.GetClubsDetailByLeagueId(leagueId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getClubDetailByClubId")]
        public IActionResult GetClubDetailByClubId(int clubId)
        {
            var result = _clubService.GetClubDetailByClubId(clubId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
