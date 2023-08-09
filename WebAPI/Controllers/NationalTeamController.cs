using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalTeamController : ControllerBase
    {
        INationalTeamService _nationalService;

        public NationalTeamController(INationalTeamService nationalService)
        {
            _nationalService = nationalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _nationalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _nationalService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(NationalTeam nationalTeam)
        {
            var result = _nationalService.Add(nationalTeam);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(NationalTeam nationalTeam)
        {
            var result = _nationalService.Update(nationalTeam);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(NationalTeam nationalTeam)
        {
            var result = _nationalService.Delete(nationalTeam);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("getnationalteamDetailbycountryıd")]
        public IActionResult GetNationalTeamsByCountryId(int countryId)
        {
            var result = _nationalService.GetNationalTeamsDetailByCountryId(countryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
