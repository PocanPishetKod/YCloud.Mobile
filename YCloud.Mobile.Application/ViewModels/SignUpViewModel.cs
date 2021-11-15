using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Application.Models;

namespace YCloud.Mobile.Application.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;

        public SignUpModel SignUpModel { get; }

        public SignUpViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;
            SignUpModel = new SignUpModel();
        }

        public async Task SignUp()
        {
            if (!SignUpModel.IsValid())
                return;

            await _authenticationService.SignUp(SignUpModel.Email, SignUpModel.Password);
            await _navigationService.NavigateToRoot();
        }

        public async Task GoToSignIn()
        {
            await _navigationService.Navigate<SignInViewModel>();
        }
    }
}
