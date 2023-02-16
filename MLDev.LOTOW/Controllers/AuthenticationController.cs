using Microsoft.AspNetCore.Mvc;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Services;
using MLDev.LOTOW.Services.Interfaces;

namespace MLDev.LOTOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IUserAuthenticationService _userAuthenticationService;

        public AuthenticationController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
        {
            var result = await _userAuthenticationService.RegisterNewUser(user);
            if (result.Succeeded)
            {
                return CreatedAtAction(nameof(Register), user);
            }
            else
            {
                return Conflict(result);
            }
        }
    }
}
