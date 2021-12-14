using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace YCloud.Mobile.Common.Configuration
{
    public class Configuration
    {
        private IConfigurationRoot _configuration;

        public Configuration()
        {
            BuildConfiguration();
        }

        public string GetSettingValue(params string[] sections)
        {
            if (sections == null || sections.Length == 0)
                throw new ArgumentNullException(nameof(sections));

            var section = FindSection(sections);
            if (section == null)
                throw new InvalidOperationException($"Setting '{sections.Last()}' not found");

            return section.Value;
        }

        private IConfigurationSection FindSection(string[] sections)
        {
            IConfigurationSection result = null;

            foreach (string section in sections)
            {
                if (result == null)
                    result = _configuration.GetSection(section);
                else
                    result = result.GetSection(section);
            }

            return result;
        }

        private void BuildConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}