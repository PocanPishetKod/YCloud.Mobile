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

        public SignUpModel SignUpModel { get; }

        public SignUpViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            _authenticationService = authenticationService;
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
