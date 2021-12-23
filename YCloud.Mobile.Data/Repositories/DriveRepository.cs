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

namespace YCloud.Mobile.Data.Repositories
{
    public class DriveRepository : IDriveRepository
    {
        private readonly DrivesClient _drivesClient;

        public DriveRepository(IYCloudConfiguration yCloudConfiguration, IReadOnlyAuthenticationState authenticationState)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (q, w, e, r) => true;

            _drivesClient = new DrivesClient(new JsonSerialization(),
                yCloudConfiguration.BaseUrl,
                authenticationState.GetAccessToken(), httpClientHandler);
        }

        public async Task<DriveDto> GetDrive(string userId)
        {
            var result = await _drivesClient.GetDrive();
            if (!result.Success && result.ResultCode != Client.Results.GetDriveResultCode.DriveNotFound)
                throw new InvalidOperationException("Get drive call error");

            return result.Drive != null ? Mapper.Map(result.Drive) : null;
        }
    }
}
