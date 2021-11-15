using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YCloud.Mobile.Application.ViewModels;

namespace YCloud.Mobile.Pages.Directory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectoryPage : ContentPage
    {
        private readonly DirectoryViewModel _viewModel;

        public DirectoryPage(DirectoryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;

            directoryItems.ItemsSource = new List<string>()
            {
                "asdsad", "asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad", "asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad"
            };
        }
    }
}