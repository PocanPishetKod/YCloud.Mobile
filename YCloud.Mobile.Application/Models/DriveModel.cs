using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Application.Models
{
    public class DriveModel
    {
        public string Id { get; set; }

        public string RootDirectoryId { get; set; }

        public long Size { get; set; }

        public long MaxSize { get; set; }
    }
}
