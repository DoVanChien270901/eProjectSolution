using ArtGallery.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallary.Application.System.Admin
{
    public interface IUserServices
    {
        Task<User> GetUser(string uname);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> CreateUser(string name, string pass);
        Task<bool> UpdateUser(User uname);
        Task<bool> DeleteUser(string uname);
        Task<IEnumerable<User>> SearchUsers(string uname);
    }
}
