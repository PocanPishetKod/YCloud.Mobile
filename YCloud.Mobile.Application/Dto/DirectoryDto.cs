using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Application.Dto
{
    public class DirectoryDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public string ParentDirectoryId { get; set; }

        public ICollection<DirectoryDto> Directories { get; set; }

        public ICollection<FileDto> Files { get; set; }
    }
}
