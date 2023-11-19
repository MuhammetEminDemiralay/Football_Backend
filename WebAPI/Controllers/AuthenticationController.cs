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

            //var userToCheck = await _authService.UserExist(userForRegisterDto.Email);


            var registerResult = _authService.Register(userForRegisterDto);

            if(registerResult != null)
            {
                return Ok(registerResult.Data);
            }

            return BadRequest();
            // Kullanıcı varmı(email control)
            // Kullanıcı varsa şifeyi haşle, kullanıcı oluştur, kullanıcı ekle, geri döndür.
            // kaydedilen kullanıcıyı token oluşturmak için geri döndür. Token Oluştur.


        }

    }
}
