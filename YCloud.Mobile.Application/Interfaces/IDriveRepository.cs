using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Models;

namespace YCloud.Mobile.Application.Interfaces
{
    public interface IDriveRepository
    {
        Task<DriveModel> GetDrive(string userId);
    }
}
