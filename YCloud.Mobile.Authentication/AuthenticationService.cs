using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Dto;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Application.Models;

namespace YCloud.Mobile.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<UserDto> GetUser()
        {
            return Task.FromResult(new UserDto() { Email = "email", Id = "qwerty" });
        }

        public Task<bool> IsAuthenticated()
        {
            return Task.FromResult(true);
        }

        public Task<UserDto> SignIn(string email, string password)
        {
            return Task.FromResult(new UserDto() { Email = email, Id = "qwerty" });
        }

        public Task<UserDto> SignUp(string email, string password)
        {
            return Task.FromResult(new UserDto() { Email = email, Id = "qwerty" });
        }
    }
}
