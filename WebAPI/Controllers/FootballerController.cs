using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _footballerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _footballerService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Footballer footballer)
        {
            var result = _footballerService.Add(footballer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Footballer footballer)
        {
            var result = _footballerService.Update(footballer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Footballer footballer)
        {
            var result = _footballerService.Delete(footballer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getFootballersByClubId")]
        public IActionResult GetFootballersByClubId(int footballerId)
        {
            var result = _footballerService.GetFootballersByClubId(footballerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
