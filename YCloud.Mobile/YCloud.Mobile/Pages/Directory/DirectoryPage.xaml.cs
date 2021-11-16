using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YCloud.Mobile.Application.Models;
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
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnLoad();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await _viewModel.OnDirectoryItemTapped(e.Item as FileSystemElementModel);
        }
    }
}