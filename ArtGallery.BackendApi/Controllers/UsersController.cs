using ArtGallary.Application.System.Users;
using ArtGallery.ViewModel.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromForm] LoginRequest request)
        {
            //if (!ModelState.IsValid) return BadRequest();
            var resultToken = await _userService.Authencate(request);
            if (string.IsNullOrEmpty(resultToken)) return BadRequest(resultToken);
            return Ok(new { token = resultToken });
        }
    }
}
