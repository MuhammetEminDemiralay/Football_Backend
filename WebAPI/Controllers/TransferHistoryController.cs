using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferHistoryController : ControllerBase
    {
        ITransferHistoryService _transferHistoryService;

        public TransferHistoryController(ITransferHistoryService transferHistoryService)
        {
            _transferHistoryService = transferHistoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _transferHistoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _transferHistoryService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(TransferHistory transferHistory)
        {
            var result = _transferHistoryService.Add(transferHistory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(TransferHistory transferHistory)
        {
            var result = _transferHistoryService.Update(transferHistory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(TransferHistory transferHistory)
        {
            var result = _transferHistoryService.Delete(transferHistory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
