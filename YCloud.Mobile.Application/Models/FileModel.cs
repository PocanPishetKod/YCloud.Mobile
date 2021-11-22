using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YCloud.Mobile.Application.Dto;

namespace YCloud.Mobile.Application.Models
{
    public class FileModel : FileSystemElementModel
    {
        private static readonly IReadOnlyCollection<string> _imageExtensions = new List<string>()
        {
            "png", "jpg", "gif", "jpeg", "svg"
        };

        private string _extension;
        private byte[] _data;

        public string DirectoryId { get; set; }

        public override string IconUri => "file_48x48.png";

        public bool IsImage => _imageExtensions.Any(e => e.Equals(Extension, StringComparison.OrdinalIgnoreCase));

        public byte[] Data 
        {
            get => _data;
            set
            {
                _data = value ?? new byte[0];
                NotifyPropertyChanged(nameof(Data));
            }
        }

        private string Extension
        {
            get
            {
                if (_extension == null)
                    _extension = Name.Substring(Name.IndexOf('.') + 1);

                return _extension;
            }
        }

        private FileModel(string id, string name, long size, string directoryId)
            : base(id, name, size)
        {
            DirectoryId = directoryId;
            Data = new byte[0];
        }

        public static FileModel Create(FileDto fileDto)
        {
            return new FileModel(fileDto.Id, fileDto.Name, fileDto.Size, fileDto.DirectoryId);
        }
    }
}
