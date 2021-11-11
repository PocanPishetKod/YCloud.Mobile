using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Application.Models
{
    public class DirectoryModel
    {
        public string Id { get; set; }

        public string ParentDirectoryId { get; set; }

        public long Size { get; set; }

        public ICollection<DirectoryModel> Directories { get; set; }

        public ICollection<FileModel> Files { get; set; }
    }
}
