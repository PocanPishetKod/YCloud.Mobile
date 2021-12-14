using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YCloud.Mobile.Common.Configuration;

namespace YCloud.Mobile.Common.Configuration
{
    public class AuthConfiguration : IAuthConfiguration
    {
        private const string BaseSection = "Authentication";
        private readonly Configuration _configuration;

        public AuthConfiguration(Configuration configuration)
        {
            _configuration = configuration;
        }

        public string Scope => _configuration.GetSettingValue(BaseSection, "Scope");

        public string ClientId => _configuration.GetSettingValue(BaseSection, "ClientId");

        public string RedirectUri => _configuration.GetSettingValue(BaseSection, "RedirectUri");

        public string BaseUrl => _configuration.GetSettingValue(BaseSection, "BaseUrl");
    }
}