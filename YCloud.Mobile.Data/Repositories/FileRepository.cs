using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Dto;
using YCloud.Mobile.Application.Interfaces;

namespace YCloud.Mobile.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
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
    }
}
