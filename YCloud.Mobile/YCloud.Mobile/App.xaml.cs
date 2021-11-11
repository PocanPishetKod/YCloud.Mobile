using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YCloud.Mobile.Application.ViewModels;
using YCloud.Mobile.Pages.SignIn;
using YCloud.Mobile.Pages.SignUp;

namespace YCloud.Mobile
{
    public partial class App : Xamarin.Forms.Application
    {
        private readonly ApplicationViewModel _viewModel;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = new NavigationPage();
            _viewModel = serviceProvider.GetService<ApplicationViewModel>();
        }

        protected override async void OnStart()
        {
            await _viewModel.CheckAuthentication();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
