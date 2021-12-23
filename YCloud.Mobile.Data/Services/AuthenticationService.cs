using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YAuth.Client;
using YAuth.Client.Models;
using YCloud.Mobile.Application.Dto;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Common.Configuration;
using YCloud.Mobile.Data.Serialization;

namespace YCloud.Mobile.Data.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationClient _authenticationClient;
        private readonly IAuthenticationState _authenticationState;
        private User _user;

        public AuthenticationService(IAuthConfiguration authConfiguration, IAuthenticationState authenticationState)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (q, w, e, r) => true;

            _authenticationClient =
                new AuthenticationClient(new JsonSerialization(),
                    new YAuth.Client.AuthConfiguration(authConfiguration.ClientId,
                        authConfiguration.Scope,
                        authConfiguration.RedirectUri,
                        authConfiguration.BaseUrl),
                    httpClientHandler);

            _authenticationState = authenticationState;
        }

        public Task<UserDto> GetUser()
        {
            if (_user == null)
                throw new InvalidOperationException("User is not authenticated");

            return Task.FromResult(new UserDto() { Email = _user.Email, Id = _user.Id });
        }

        public Task<bool> IsAuthenticated()
        {
            return Task.FromResult(_user != null);
        }

        public async Task<UserDto> SignIn(string email, string password)
        {
            var result = await _authenticationClient.SignIn(email, password);
            if (!result.Success)
                throw new InvalidOperationException("Error authenticate operation");

            _user = result.User;
            _authenticationState.SetAccessToken(result.AccessToken);
            return new UserDto() { Email = _user.Email, Id= _user.Id };
        }

        public async Task<UserDto> SignUp(string email, string password)
        {
            var result = await _authenticationClient.SignUp(email, password);
            if (!result.Success)
                throw new InvalidOperationException("Error authenticate operation");

            _user = result.User;
            _authenticationState.SetAccessToken(result.AccessToken);
            return new UserDto() { Email = _user.Email, Id= _user.Id };
        }
    }
}
