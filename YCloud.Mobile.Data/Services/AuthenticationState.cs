using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Data.Services
{
    public interface IReadOnlyAuthenticationState
    {
        string GetAccessToken();
    }

    public interface IAuthenticationState
    {
        string GetAccessToken();
        void SetAccessToken(string accessToken);
    }

    public class AuthenticationState : IAuthenticationState, IReadOnlyAuthenticationState
    {
        private string _accessToken;

        public string GetAccessToken()
        {
            return _accessToken;
        }

        public void SetAccessToken(string accessToken)
        {
            if (_accessToken != null)
                throw new InvalidOperationException("AccessToken already set");

            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            _accessToken = accessToken;
        }
    }
}
