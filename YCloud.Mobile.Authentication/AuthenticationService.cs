using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Application.Models;

namespace YCloud.Mobile.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<bool> IsAuthenticated()
        {
            return Task.FromResult(true);
        }

        public Task<UserModel> SignIn(string email, string password)
        {
            return Task.FromResult(new UserModel() { Email = email, Id = "qwerty" });
        }

        public Task<UserModel> SignUp(string email, string password)
        {
            return Task.FromResult(new UserModel() { Email = email, Id = "qwerty" });
        }
    }
}
