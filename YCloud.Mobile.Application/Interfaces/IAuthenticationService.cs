using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Models;

namespace YCloud.Mobile.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserModel> SignIn(string email, string password);

        Task<UserModel> SignUp(string email, string password);

        Task<bool> IsAuthenticated();
    }
}
