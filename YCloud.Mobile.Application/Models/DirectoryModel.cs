using System;
using System.Collections.Generic;
using System.Text;
using YCloud.Mobile.Application.Dto;

namespace YCloud.Mobile.Application.Models
{
    public class DirectoryModel : FileSystemElementModel
    {
        public override string IconUri => "directory.png";

        private DirectoryModel(string id, string name, long size)
            : base(id, name, size)
        {
            
        }

        public static DirectoryModel Create(DirectoryDto directoryDto)
        {
            return new DirectoryModel(directoryDto.Id, directoryDto.Name, directoryDto.Size);
        }
    }
}
