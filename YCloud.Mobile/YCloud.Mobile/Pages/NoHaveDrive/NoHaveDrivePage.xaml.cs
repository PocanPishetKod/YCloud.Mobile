using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YCloud.Mobile.Application.ViewModels;

namespace YCloud.Mobile.Pages.NoHaveDrive
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoHaveDrivePage : ContentPage
    {
        public NoHaveDrivePage(NoHaveDriveViewModel viewModel)
        {
            InitializeComponent();
            
            BindingContext = viewModel;
        }
    }
}