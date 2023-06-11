using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userLogin = _authService.Login(userForLoginDto);
            if (userLogin.IsSuccess)
            {
                var token = _authService.CreateAccessToken(userLogin.Data);
                if (token.IsSuccess)
                    return Ok(token);
                else
                    return BadRequest(token);
            }
            
            return BadRequest(userLogin);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.IsSuccess)
            {
                return BadRequest(userExists.Message);
            }
            var userRegister = _authService.Register(userForRegisterDto,userForRegisterDto.Password);
            if (userRegister.IsSuccess)
            {
                var token = _authService.CreateAccessToken(userRegister.Data);
                if (token.IsSuccess)
                    return Ok(token);
                else
                    return BadRequest(token);
            }

            return BadRequest(userRegister);
        }
    }
}
