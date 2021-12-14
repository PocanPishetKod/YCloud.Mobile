using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YAuth.Client;
using YCloud.Mobile.Application.Dto;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Common.Configuration;
using YCloud.Mobile.Data.Serialization;

namespace YCloud.Mobile.Data.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationClient _authenticationClient;

        public AuthenticationService(IAuthConfiguration authConfiguration)
        {
            _authenticationClient =
                new AuthenticationClient(new JsonSerialization(),
                    new YAuth.Client.AuthConfiguration(authConfiguration.ClientId,
                        authConfiguration.Scope,
                        authConfiguration.RedirectUri,
                        authConfiguration.BaseUrl));
        }

        public Task<UserDto> GetUser()
        {
            return Task.FromResult(new UserDto() { Email = "test@test.ru", Id = "userId" });
        }

        public Task<bool> IsAuthenticated()
        {
            return Task.FromResult(true);
        }

        public Task<UserDto> SignIn(string email, string password)
        {
            return Task.FromResult(new UserDto() { Email = email, Id = "userId" });
        }

        public Task<UserDto> SignUp(string email, string password)
        {
            return Task.FromResult(new UserDto() { Email = email, Id = "userId" });
        }
    }
}
