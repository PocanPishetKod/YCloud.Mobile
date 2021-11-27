using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public ICommand ItemMenuTapCommand => new Command((parameter) => OnItemMenuTapped(parameter));

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
                if (selectedFiles?.Any() ?? false)
                    await _viewModel.UploadFiles(selectedFiles.Select(f => new SelectedFile(f)).ToList());
            }
            else if (selectedAction.Equals(createDirectory))
            {
                var directoryName = await ShowInputDirectoryNameDialog();
                if (directoryName == null)
                    return;

                if (string.IsNullOrWhiteSpace(directoryName))
                {
                    await DisplayAlert("Ошибка", "Имя папки не должно быть пустым", "Ok");
                }
                else
                {
                    await _viewModel.CreateDirectory(directoryName);
                }
            }
        }

        private async void OnItemMenuTapped(object parameter)
        {
            const string delete = "Удалить";

            var fileSystemElement = parameter as FileSystemElementModel;
            var selectedAction = await DisplayActionSheet("Меню", "Отмена", null, delete);

            if (selectedAction == null)
                return;

            if (selectedAction.Equals(delete))
            {
                var deleteAccepted = await DisplayAlert("Подтверждение", "Вы действительно произвести удаление?", "Да", "Нет");
                if (!deleteAccepted)
                    return;

                if (fileSystemElement is FileModel fileModel)
                {
                    await _viewModel.DeleteFile(fileModel);
                }
                else if (fileSystemElement is DirectoryModel directoryModel)
                {
                    await _viewModel.DeleteDirectory(directoryModel);
                }
            }
        }

        private async Task<string> ShowInputDirectoryNameDialog()
        {
            return await DisplayPromptAsync("Создание папки", string.Empty);
        }

        private async void RefreshingItems(object sender, EventArgs e)
        {
            await _viewModel.OnRefresh();
            directoryItems.EndRefresh();
        }

        private void LongPressEffect_LongPressed(object sender, EventArgs e)
        {
            Console.WriteLine("Long pressed");
        }
    }
}