using Business.Abstract;
using Entities.Concrete;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballerController : ControllerBase
    {
        IFootballerService _footballerService;

        public FootballerController(IFootballerService footballerService)
        {
            _footballerService = footballerService;
        }

        [HttpGet("yakala")]
        public async Task<IActionResult> GetYakala([FromQuery] FootballerParameters parameters)
        {
            var result = await _footballerService.GetAllPaginationFootballer(parameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));

            if (result.metaData.TotalCount > 0)
            {
                return Ok(result.footballer);
            }

            return BadRequest();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync(int minAge, int maxAge)
        {
            var result = await _footballerService.GetAllAsync(minAge, maxAge);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _footballerService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(Footballer footballer)
        {
            var result = await _footballerService.AddAsync(footballer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(Footballer footballer)
        {
            var result = await _footballerService.UpdateAsync(footballer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(Footballer footballer)
        {
            var result = await _footballerService.DeleteAsync(footballer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getFootballersByClubId")]
        public async Task<IActionResult> GetFootballersByClubIdAsync(int clubId)
        {
            var result = await _footballerService.GetFootballersByClubIdAsync(clubId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getFootballersDetailByClubId")]
        public async Task<IActionResult> GetFootballersDetailByClubIdAsync(int clubId)
        {
            var result = await _footballerService.GetFootballersDetailByClubIdAsync(clubId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getFootballerDetailByFootballerId")]
        public async Task<IActionResult> GetFootballerDetailByFootballerIdAsync(int footballerId)
        {
            var result = await _footballerService.GetFootballerDetailByFootballerIdAsync(footballerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getFootballerDetailByNationalTeam")]
        public async Task<IActionResult> GetFootballerDetailByNationalTeamAsync(int countryId, bool nationalTeam, int nationalTeamLevel)
        {
            var result = await _footballerService.GetFootballerDetailByCountryIdAsync(countryId, nationalTeam, nationalTeamLevel);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
