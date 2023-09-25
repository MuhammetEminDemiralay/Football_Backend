using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _positionService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _positionService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(Position positon)
        {
            var result = await _positionService.AddAsync(positon);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(Position positon)
        {
            var result = await _positionService.UpdateAsync(positon);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(Position positon)
        {
            var result = await _positionService.DeleteAsync(positon);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
