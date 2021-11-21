using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YCloud.Mobile.Application.Models;
using YCloud.Mobile.Application.ViewModels;
using YCloud.Mobile.Implementation;

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

        private async void OnMenuTapped(object sender, EventArgs e)
        {
            const string loadFile = "Загрузить файл";
            const string createDirectory = "Создать папку";
            var selectedAction = await DisplayActionSheet("Меню", "Отмена", null, loadFile, createDirectory);

            if (selectedAction == null)
                return;

            if (selectedAction.Equals(loadFile))
            {
                var selectedFiles = await FilePicker.PickMultipleAsync();
                if (selectedFiles.Any())
                    await _viewModel.UploadFiles(selectedFiles.Select(f => new SelectedFile(f)).ToList());
            }
        }
    }
}