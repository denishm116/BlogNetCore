using BlogNetCore.Models.DataContracts.UserContracts;
using BlogNetCore.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
namespace BlogNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        

        public AuthController(IAuthService userService)
        {
            _authService = userService;
        }

        // /api/auth/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterUserAsync(model);

                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");

        }

        // /api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginUserAsync(model);

                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");

        }

        [Authorize]
        [HttpPost("User")]
        public async Task<object> GetUser()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            IdentityUser user = await _authService.GetUserAsync(userId);
            var nuxtUser = new UserForNuxtDto()
            {
                User = user
            };
             return nuxtUser;
        }

        
        [Authorize]
        [HttpGet("Logout")]
        public void Logout()
        {
           _authService.Logout();
        }


    }

}
