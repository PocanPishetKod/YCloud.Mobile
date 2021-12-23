using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YCloud.Mobile.Application.ViewModels;

namespace YCloud.Mobile.Pages.SignIn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        private readonly SignInViewModel _viewModel;

        public SignInPage(SignInViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        public async void OnSignInButtonClicked(object sender, EventArgs e)
        {
            await _viewModel.SignIn();
        }

        public async void OnCreateAnAccountButtonClicked(object sender, EventArgs e)
        {
            await _viewModel.GoToSignUp();
        }
    }
}