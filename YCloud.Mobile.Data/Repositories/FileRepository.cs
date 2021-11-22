using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Dto;
using YCloud.Mobile.Application.Interfaces;

namespace YCloud.Mobile.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private static int _currentImage = 1;

        public Task<IReadOnlyCollection<FileDto>> UploadFiles(IReadOnlyCollection<ISelectedFile> selectedFiles, string directoryId, string driveId)
        {
            IReadOnlyCollection<FileDto> result = selectedFiles.Select(f => new FileDto()
            {
                Id = Guid.NewGuid().ToString(),
                DirectoryId = directoryId,
                Name = f.Name,
                Size = 1024
            })
                .ToList();

            return Task.FromResult(result);
        }

        public Task<Stream> DownloadFile(string fileId)
        {
            if (_currentImage == 1)
            {
                _currentImage++;
                return Task.FromResult(GetFileStream("itachi_1.png"));
            }
            else
            {
                _currentImage = 1;
                return Task.FromResult(GetFileStream("itachi_2.png"));
            }
        }

        private Stream GetFileStream(string fileName)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(FileRepository)).Assembly;
            return assembly.GetManifestResourceStream($"YCloud.Mobile.Data.{fileName}");
        }
    }
}
