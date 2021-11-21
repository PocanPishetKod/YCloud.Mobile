using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Dto;

namespace YCloud.Mobile.Application.Interfaces
{
    public interface IFileRepository
    {
        Task<IReadOnlyCollection<FileDto>> UploadFiles(IReadOnlyCollection<ISelectedFile> selectedFiles, string directoryId, string driveId);
    }
}
