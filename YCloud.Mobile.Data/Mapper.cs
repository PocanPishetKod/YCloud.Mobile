using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YCloud.Mobile.Application.Dto;
using YCloudDirectoryDto = YCloud.Client.Dto.DirectoryDto;
using YCloudFileDto = YCloud.Client.Dto.FileDto;
using YCloudDriveDto = YCloud.Client.Dto.DriveDto;

namespace YCloud.Mobile.Data
{
    internal static class Mapper
    {
        public static DirectoryDto Map(YCloudDirectoryDto yCloudDirectoryDto)
        {
            var result = new DirectoryDto()
            {
                Id = yCloudDirectoryDto.Id,
                Name = yCloudDirectoryDto.Name,
                Size = yCloudDirectoryDto.Size,
                Directories = new List<DirectoryDto>(),
                Files = new List<FileDto>()
            };

            if (yCloudDirectoryDto.Files?.Count > 0)
                result.Files = yCloudDirectoryDto.Files.Select(Map).ToList();

            if (yCloudDirectoryDto.Directories?.Count > 0)
                result.Directories = yCloudDirectoryDto.Directories.Select(Map).ToList();

            return result;
        }

        public static FileDto Map(YCloudFileDto yCloudFileDto)
        {
            return new FileDto()
            {
                Id=yCloudFileDto.Id,
                Name = yCloudFileDto.Name,
                Size = yCloudFileDto.Size,
                DirectoryId = yCloudFileDto.DirectoryId,
            };
        }

        public static DriveDto Map(YCloudDriveDto yCloudDriveDto)
        {
            return new DriveDto()
            {
                Id = yCloudDriveDto.Id,
                MaxSize = yCloudDriveDto.MaxSize,
                Size = yCloudDriveDto.TotalSize,
                RootDirectoryId = yCloudDriveDto.RootDirectoryId,
            };
        }
    }
}
