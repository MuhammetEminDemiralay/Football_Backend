using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentController : ControllerBase
    {
        IContinentService _continentService;

        public ContinentController(IContinentService continentService)
        {
            _continentService = continentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _continentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _continentService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Continent continent)
        {
            var result = _continentService.Add(continent);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Continent continent)
        {
            var result = _continentService.Update(continent);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Continent continent)
        {
            var result = _continentService.Delete(continent);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
