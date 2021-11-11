using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Application.Models;

namespace YCloud.Mobile.Application.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

        public SignInModel SignInModel { get; }

        public SignInViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            _authenticationService = authenticationService;
            SignInModel = new SignInModel();
        }

        public async Task SignIn()
        {
            if (!SignInModel.IsValid())
                return;

            await _authenticationService.SignIn(SignInModel.Email, SignInModel.Password);
            await _navigationService.NavigateToRoot();
        }

        public async Task GoToSignUp()
        {
            await _navigationService.Navigate<SignUpViewModel>();
        }
    }
}
