using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YCloud.Client;
using YCloud.Mobile.Application.Dto;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Common.Configuration;
using YCloud.Mobile.Data.Serialization;
using YCloud.Mobile.Data.Services;
using YCloudDirectoryDto = YCloud.Client.Dto.DirectoryDto;

namespace YCloud.Mobile.Data.Repositories
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly DirectoriesClient _directoriesClient;

        public DirectoryRepository(IReadOnlyAuthenticationState authenticationState, IYCloudConfiguration yCloudConfiguration)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (q, w, e, r) => true;

            _directoriesClient = new DirectoriesClient(new JsonSerialization(),
                yCloudConfiguration.BaseUrl,
                authenticationState.GetAccessToken(),
                httpClientHandler);
        }

        public async Task<DirectoryDto> GetDirectory(string id)
        {
            var result = await _directoriesClient.GetDirectory(id);
            if (!result.Success)
                throw new InvalidOperationException("GetDirectory call error");

            return Mapper.Map(result.Directory);
        }

        public async Task<DirectoryDto> Create(string directoryName, string parentDirectoryId, string driveId)
        {
            var result = await _directoriesClient.CreateDirectory(directoryName, parentDirectoryId);
            if (!result.Success)
                throw new InvalidOperationException("Create directory call error");

            return Mapper.Map(result.Directory);
        }

        public async Task Delete(string id)
        {
            var result = await _directoriesClient.DeleteDirectory(id);
            if (!result.Success)
                throw new InvalidOperationException("Delete directory call error");
        }
    }
}
