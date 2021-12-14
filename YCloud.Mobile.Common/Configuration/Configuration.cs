using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies
                .FirstOrDefault(a => a.GetName().Name.EndsWith("Android") || a.GetName().Name.EndsWith("IOS"));

            if (assembly == null)
                throw new InvalidOperationException("Main assembly not found");

            var resourceName = assembly
                .GetManifestResourceNames()
                .FirstOrDefault(r => r.EndsWith("appsettings.json"));

            if (resourceName == null)
                throw new InvalidOperationException("appsettings.json not found");

            _configuration = new ConfigurationBuilder()
                .AddJsonStream(assembly.GetManifestResourceStream(resourceName))
                .Build();
        }
    }
}