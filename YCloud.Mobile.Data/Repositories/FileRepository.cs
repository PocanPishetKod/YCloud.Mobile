using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YCloud.Client;
using YCloud.Mobile.Application.Dto;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Common.Configuration;
using YCloud.Mobile.Data.Serialization;
using YCloud.Mobile.Data.Services;

namespace YCloud.Mobile.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FilesClient _filesClient;

        public FileRepository(IYCloudConfiguration yCloudConfiguration, IReadOnlyAuthenticationState authenticationState)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (q, w, e, r) => true;

            _filesClient = new FilesClient(new JsonSerialization(),
                yCloudConfiguration.BaseUrl,
                authenticationState.GetAccessToken(), httpClientHandler);
        }

        public async Task<IReadOnlyCollection<FileDto>> UploadFiles(IReadOnlyCollection<ISelectedFile> selectedFiles, string directoryId, string driveId)
        {
            var result = new List<FileDto>();

            foreach (var file in selectedFiles)
            {
                using var fileStream = await file.OpenRead();
                var processResult = await _filesClient.UploadFile(fileStream, file.Name, directoryId);
                if (!processResult.Success)
                    throw new InvalidOperationException("Upload file call error");

                result.Add(Mapper.Map(processResult.File));
            }

            return result;
        }

        public async Task<Stream> DownloadFile(string fileId)
        {
            var result = await _filesClient.DownloadFile(fileId);
            if (!result.Success)
                throw new InvalidOperationException("Download file call error");

            return result.Stream;
        }

        public async Task Delete(string Id)
        {
            var result = await _filesClient.DeleteFile(Id);
            if (!result.Success)
                throw new InvalidOperationException("Delete file call error");
        }
    }
}
