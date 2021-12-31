using ArtGallery.Application.System.Admin;
using ArtGallery.Data.Entities;
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
    public class UsersManagerController : ControllerBase
    {
        private readonly IUserServices userServices;
        public UsersManagerController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpPost("{name}/{pass}")]
        public async Task<bool> CreateUser(string name, string pass)
        {
            return await userServices.CreateUser(name, pass);
        }

        [HttpDelete("{name}")]
        public async Task<bool> DeleteUser(string name)
        {
            return await userServices.DeleteUser(name);
        }

        [HttpPut]
        public async Task<bool> UpdateUser(User user)
        {
            return await userServices.UpdateUser(user);
        }

        [HttpGet("searchbyName/{uname}")]
        public async Task<IEnumerable<User>> SearchUsers(string uname)
        {
            return await userServices.SearchUsers(uname);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userServices.GetUsers();
        }

        [HttpGet("{name}")]
        public async Task<User> GetUser(string name)
        {
            return await userServices.GetUser(name);
        }
    }
}
