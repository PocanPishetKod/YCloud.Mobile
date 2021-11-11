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
        public SignInPage(SignInViewModel viewModel)
        {
            InitializeComponent();
        }
    }
}