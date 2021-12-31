using ArtGallery.Data.Entities;
using ArtGallery.ViewModel.System.Admin;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArtGallery.AdminApp.Controllers
{
    public class UserManagerController : Controller
    {
        private readonly string url = "http://localhost:4086/api/UsersManager/";
        private readonly HttpClient httpClient = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<User>>(httpClient.GetStringAsync(url).Result);
            UserModelView userModelView = new UserModelView { Users = model}; 
            return View(userModelView);
        }

        [HttpGet]
        public IActionResult Details(string name)
        {
            var model = JsonConvert.DeserializeObject<User>(httpClient.GetStringAsync(url+name).Result);
            UserModelView userModelView = new UserModelView { 
                User = model, 
                Carts = model.Carts, 
                Orders = model.Orders, 
                Transactions = model.Transactions, 
                FeedBacks = model.FeedBacks, 
                ProfileUser = model.ProfileUser
            };
            return View(userModelView);
        }




    }
}
