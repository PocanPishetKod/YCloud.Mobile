using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Common.Configuration
{
    public class YCloudConfiguration : IYCloudConfiguration
    {
        private readonly Configuration _configuration;

        public YCloudConfiguration(Configuration configuration)
        {
            _configuration = configuration;
        }

        public string BaseUrl => _configuration.GetSettingValue("YCloud", "BaseUrl");
    }
}
