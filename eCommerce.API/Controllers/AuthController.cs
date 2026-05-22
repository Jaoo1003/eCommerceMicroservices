using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest is null)
            {
                return BadRequest("Invalid login data");
            }

            AuthenticationResponse? authenticationResponse = await _userService.Login(loginRequest);

            if (authenticationResponse is null || authenticationResponse.Success == false)
            {
                return Unauthorized(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if(registerRequest is null)
            {
                return BadRequest("Invalid registration data");
            }

            AuthenticationResponse? authenticationResponse = await _userService.Register(registerRequest);

            if(authenticationResponse is null || authenticationResponse.Success == false)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }
    }
}
