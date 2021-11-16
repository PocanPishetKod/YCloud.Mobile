using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Dto;
using YCloud.Mobile.Application.Interfaces;

namespace YCloud.Mobile.Data.Repositories
{
    public class DriveRepository : IDriveRepository
    {
        public Task<DriveDto> GetDrive(string userId)
        {
            var result = new DriveDto()
            {
                Id = userId,
                RootDirectoryId = "RootDirId",
                Size = 1024,
                MaxSize = 2048
            };

            return Task.FromResult(result);
        }
    }
}
