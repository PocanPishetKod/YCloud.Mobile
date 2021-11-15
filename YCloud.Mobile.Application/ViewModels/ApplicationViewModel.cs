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
        private readonly INavigationService _navigationService;

        public ApplicationViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;
        }

        public async Task CheckAuthentication()
        {
            if (await _authenticationService.IsAuthenticated())
                await _navigationService.Navigate<DirectoryViewModel>();
            else
                await _navigationService.Navigate<SignInViewModel>();
        }
    }
}
