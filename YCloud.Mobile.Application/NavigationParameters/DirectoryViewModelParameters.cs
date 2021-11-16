using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Application.NavigationParameters
{
    public class DirectoryViewModelParameters
    {
        public string DirectoryId { get; }

        public DirectoryViewModelParameters()
        {
            DirectoryId = string.Empty;
        }

        public DirectoryViewModelParameters(string directoryId)
        {
            DirectoryId = directoryId;
        }
    }
}
