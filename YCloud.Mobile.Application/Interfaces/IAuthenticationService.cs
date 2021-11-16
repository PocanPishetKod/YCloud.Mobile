using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Dto;

namespace YCloud.Mobile.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserDto> SignIn(string email, string password);

        Task<UserDto> SignUp(string email, string password);

        Task<bool> IsAuthenticated();

        Task<UserDto> GetUser();
    }
}
