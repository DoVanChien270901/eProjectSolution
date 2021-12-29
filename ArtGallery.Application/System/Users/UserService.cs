using ArtGallery.Application.System.Users;
using ArtGallery.Data.EF;
using ArtGallery.Data.Entities;
using ArtGallery.ViewModel.System.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Application.System.Users
{
    public class UserService : IUserService
    {
        private ArtGalleryDbContext _db;
        private readonly IConfiguration _config;
        public UserService(ArtGalleryDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
        public async Task<string> Authencate(LoginRequest loginRequest)
        {
            Account user =_db.Accounts.SingleOrDefault(c=>c.Name==loginRequest.Name && c.Password == loginRequest.Password);
            if (user == null)
            {
                return null;
            }
            ProfileUser profile = _db.ProfileUsers.SingleOrDefault(c=>c.UserId == user.Name);
            //Discription token
            var clearms = new[]
            {
                    new Claim(ClaimTypes.Name, profile.FullName),
                    new Claim(ClaimTypes.Email, profile.Email),
                    new Claim(ClaimTypes.MobilePhone, profile.PhoneNumber.ToString()),
                    new Claim(ClaimTypes.Role, profile.FullName),
                    //role?

                    new Claim("TokenId", Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));// Minimun size of key(KeySize) = 126bits(16byte)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                clearms,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            //pare jwtSecurityToken to string
            return new JwtSecurityTokenHandler().WriteToken(token);     
        }
    }
}
