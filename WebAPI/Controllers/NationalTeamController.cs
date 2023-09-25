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
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _nationalService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _nationalService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(NationalTeam nationalTeam)
        {
            var result = await _nationalService.AddAsync(nationalTeam);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(NationalTeam nationalTeam)
        {
            var result = await _nationalService.UpdateAsync(nationalTeam);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(NationalTeam nationalTeam)
        {
            var result = await _nationalService.DeleteAsync(nationalTeam);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("getnationalteamDetailbycountryıd")]
        public async Task<IActionResult> GetNationalTeamsByCountryIdAsync(int countryId)
        {
            var result = await _nationalService.GetNationalTeamsDetailByCountryIdAsync(countryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getnationalteamDetailbyNationalTeamId")]
        public async Task<IActionResult> GetNationalTeamByNationalTeamIdAsync(int nationalTeamId)
        {
            var result = await _nationalService.GetNationalTeamsDetailByNationalTeamIdAsync(nationalTeamId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
