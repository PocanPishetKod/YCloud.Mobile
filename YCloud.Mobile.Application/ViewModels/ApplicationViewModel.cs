using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Interfaces;

namespace YCloud.Mobile.Application.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

        public ApplicationViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task CheckAuthentication()
        {
            if (await _authenticationService.IsAuthenticated())
                await Navigate<DirectoryViewModel>();
            else
                await Navigate<SignInViewModel>();
        }
    }
}
