using System;
using System.Collections.Generic;
using System.Text;
using YCloud.Mobile.Application.Dto;

namespace YCloud.Mobile.Application.Models
{
    public class FileModel : FileSystemElementModel
    {
        public string DirectoryId { get; set; }

        public override string IconUri => "file_48x48.png";

        private FileModel(string id, string name, long size, string directoryId)
            : base(id, name, size)
        {
            DirectoryId = directoryId;
        }

        public static FileModel Create(FileDto fileDto)
        {
            return new FileModel(fileDto.Id, fileDto.Name, fileDto.Size, fileDto.DirectoryId);
        }
    }
}
