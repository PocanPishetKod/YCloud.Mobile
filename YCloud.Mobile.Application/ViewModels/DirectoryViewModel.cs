using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Application.Models;

namespace YCloud.Mobile.Application.ViewModels
{
    public class DirectoryViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDirectoryRepository _directoryRepository;

        public DirectoryModel Directory { get; private set; }

        public DirectoryViewModel(INavigationService navigationService, IDirectoryRepository directoryRepository)
        {
            _navigationService = navigationService;
            _directoryRepository = directoryRepository;
        }

        public async Task LoadDirectory()
        {
            var loadedDirectory = await _directoryRepository.GetDirectory("");
            if (loadedDirectory == null)
                throw new NullReferenceException(nameof(loadedDirectory));

            Directory = loadedDirectory;
        }

        
    }
}
