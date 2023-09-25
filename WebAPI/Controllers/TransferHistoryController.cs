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
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _transferHistoryService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _transferHistoryService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(TransferHistory transferHistory)
        {
            var result = await _transferHistoryService.AddAsync(transferHistory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(TransferHistory transferHistory)
        {
            var result = await _transferHistoryService.UpdateAsync(transferHistory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(TransferHistory transferHistory)
        {
            var result = await _transferHistoryService.DeleteAsync(transferHistory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("gettransferhistorybyfootballerıd")]
        public async Task<IActionResult> GetTransferHistoryByFootballerIdAsync(int footbalerId)
        {
            var result = await _transferHistoryService.GetTransferHistoryByFootballerIdAsync(footbalerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
