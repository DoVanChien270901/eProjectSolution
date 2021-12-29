using ArtGallery.Data.Constants;
using ArtGallery.ViewModel.System.Users;
using ArtGallery.WebApp.Functions.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly string url = "http://localhost:5000/api/Users/authenticate/";
        private HttpClient httpClient = new HttpClient();
        public IUserService _function;
        public UsersController(IUserService function)
        {
            _function = function;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid) return View();
            var json = JsonConvert.SerializeObject(loginRequest);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            ResponseApi result = JsonConvert.DeserializeObject<ResponseApi>(await httpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync());
            if (result.Success)
            {
                var token = result.Data.ToString();
                var userPrincipal = _function.ValtdateToken(token);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(120),
                    IsPersistent = false
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    authProperties
                    );
                return RedirectToAction("Home", "Home");
            }
            ModelState.AddModelError("loginMessage", result.Message);
            return View();
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
