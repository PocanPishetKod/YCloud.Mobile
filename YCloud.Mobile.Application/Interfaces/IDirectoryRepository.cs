using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Models;

namespace YCloud.Mobile.Application.Interfaces
{
    public interface IDirectoryRepository
    {
        Task<DirectoryModel> GetDirectory(string id);
    }
}
