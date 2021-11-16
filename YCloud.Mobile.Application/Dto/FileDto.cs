using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Application.Dto
{
    public class FileDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public string DirectoryId { get; set; }
    }
}
