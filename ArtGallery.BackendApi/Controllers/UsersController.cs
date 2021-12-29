using ArtGallery.Application.System.Users;
using ArtGallery.Data.Constants;
using ArtGallery.ViewModel.System.Users;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ResponseApi> Authenticate(LoginRequest request)
        {
            var resultToken = await _userService.Authencate(request);
            if (string.IsNullOrEmpty(resultToken)) return null;
            return new ResponseApi
            {
                Message = "",
                Success = true,
                Data = resultToken
            };
        }
        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] LoginRequest request)
        {
            return Ok();
        }
    }
}
