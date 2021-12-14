using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Common.Configuration
{
    public interface IAuthConfiguration
    {
        string Scope { get; }

        string ClientId { get; }

        string RedirectUri { get; }

        string BaseUrl { get; }
    }
}
