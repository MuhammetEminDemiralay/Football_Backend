using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IAuthenticationService _authService;
        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            var userToCheck = await _authService.UserExist(userForRegisterDto.Email);
            if (!userToCheck.Success)
            {
                return BadRequest();
            }

            var registerResult = await _authService.Register(userForRegisterDto);
            var token = await _authService.CreateToken(registerResult.Data);
            if (token.Success)
            {
                return Ok(token);
            }
            return BadRequest();

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var loginResult = await _authService.Login(userForLoginDto);
            if (!loginResult.Success)
            {
                return BadRequest();
            }

            var token = await _authService.CreateToken(loginResult.Data);
            if (token.Success)
            {
                return Ok(token);
            }
            return Ok(loginResult.Message);
        }
    }
}
