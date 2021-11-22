using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Application.Models;
using YCloud.Mobile.Application.NavigationParameters;

namespace YCloud.Mobile.Application.ViewModels
{
    public class ImagesViewModel : ViewModelBase
    {
        private readonly IFileRepository _fileRepository;
        private FileModel _currentImage;

        public ObservableCollection<FileModel> Images { get; private set; }

        public FileModel CurrentImage 
        { 
            get => _currentImage;
            set
            {
                _currentImage = value;
                NotifyPropertyChanged(nameof(CurrentImage));
            } 
        }

        public ImagesViewModel(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
            Images = new ObservableCollection<FileModel>();
            PropertyChanged += OnCurrentImageChanged;
        }

        public async Task OnLoad()
        {
            await FillImages();
        }

        private async Task FillImages()
        {
            var navigationParameters = GetNavigationParameters<ImagesNavigationParameters>();
            if (navigationParameters == null)
                throw new NullReferenceException("Navigation parameters is null");

            Images.Clear();

            foreach(var file in navigationParameters.ImageFiles)
            {
                Images.Add(file);
            }

            CurrentImage = navigationParameters.CurrentImage;
            CurrentImage.Data = await DownloadFile(CurrentImage.Id);
        }

        private async void OnCurrentImageChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(CurrentImage))
                return;

            if (CurrentImage == null)
                return;

            CurrentImage.Data = await DownloadFile(CurrentImage.Id);
        }

        private async Task<byte[]> DownloadFile(string fileId)
        {
            using (var stream = await _fileRepository.DownloadFile(fileId))
            {
                var buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer, 0, buffer.Length);
                return buffer;
            }
        }
    }
}
