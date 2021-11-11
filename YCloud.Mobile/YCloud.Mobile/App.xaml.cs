using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YCloud.Mobile.Pages.Directory;
using YCloud.Mobile.Pages.SignIn;

namespace YCloud.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DirectoryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
