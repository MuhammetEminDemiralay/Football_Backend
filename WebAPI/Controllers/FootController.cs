using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootController : ControllerBase
    {
        IFootService _footService;

        public FootController(IFootService footService)
        {
            _footService = footService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _footService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _footService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Foot foot)
        {
            var result = _footService.Add(foot);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Foot foot)
        {
            var result = _footService.Update(foot);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Foot foot)
        {
            var result = _footService.Delete(foot);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
