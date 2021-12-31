using ArtGallery.Data.EF;
using ArtGallery.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Application.System.Admin
{
    public class UserServicesImp : IUserServices
    {
        private readonly ArtGalleryDbContext context;
        public UserServicesImp(ArtGalleryDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateUser(string name, string pass)
        {
            var us = context.User.SingleOrDefault(c => c.Name.Equals(name));
            if (us == null)
            {
                User user = new User { Name = name, Password = pass};
                await context.User.AddAsync(user);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUser(string uname)
        {
            var us = context.User.SingleOrDefault(c => c.Name.Equals(uname));
            if (us != null)
            {
                context.User.Remove(us);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User> GetUser(string uname)
        {
            return context.User.SingleOrDefault(u=>u.Name.Equals(uname));
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return context.User.ToList();
        }

        public async Task<IEnumerable<User>> SearchUsers(string uname)
        {
            return context.User.Where(u=>u.Name.Contains(uname));
        }

        public async Task<bool> UpdateUser(User user)
        {
            var us = context.User.SingleOrDefault(c => c.Name.Equals(user.Name));
            if (us != null)
            {
                us.Name = user.Name;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
