using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Application.Models
{
    public abstract class FileSystemElementModel
    {
        public string Id { get; }

        public string Name { get; set; }

        public long Size { get; set; }

        public abstract string IconUri { get; }

        protected FileSystemElementModel(string id, string name, long size)
        {
            Id = id;
            Name = name;
            Size = size;
        }
    }
}
