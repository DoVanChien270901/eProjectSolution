using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArtGallery.WebApp.Functions.Users
{
    public interface IUserService
    {
        public ClaimsPrincipal ValtdateToken(string jwtToken);
    }
}
