using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YCloud.Mobile.Application.ViewModels;

namespace YCloud.Mobile.Pages.SignUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private readonly SignUpViewModel _viewModel;

        public SignUpPage(SignUpViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        public async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await _viewModel.SignUp();
        }

        public async void OnSignInButtonClicked(object sender, EventArgs e)
        {
            await _viewModel.GoToSignIn();
        }
    }
}