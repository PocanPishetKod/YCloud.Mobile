using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Dto;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Application.Models;
using YCloud.Mobile.Application.NavigationParameters;

namespace YCloud.Mobile.Application.ViewModels
{
    public class DirectoryViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDirectoryRepository _directoryRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IDriveRepository _driveRepository;

        private DirectoryDto _directory;
        private DriveDto _drive;

        public ObservableCollection<FileSystemElementModel> DirectoryItems { get; private set; }
        public DriveModel Drive { get; private set; }

        public DirectoryViewModel(INavigationService navigationService, IDirectoryRepository directoryRepository,
            IAuthenticationService authenticationService, IDriveRepository driveRepository)
        {
            _navigationService = navigationService;
            _directoryRepository = directoryRepository;
            _authenticationService = authenticationService;
            _driveRepository = driveRepository;
            DirectoryItems = new ObservableCollection<FileSystemElementModel>();
        }

        public async Task OnLoad()
        {
            await LoadDrive();
            await LoadDirectory();
            FillDirectoryItems();
        }

        public async Task OnDirectoryItemTapped(FileSystemElementModel directoryItem)
        {
            if (directoryItem is DirectoryModel directoryModel)
                await OpenDirectory(directoryModel);
            else
                await OpenFile(directoryItem as FileModel);
        }

        private async Task OpenDirectory(DirectoryModel directory)
        {
            await _navigationService
                .Navigate<DirectoryViewModel, DirectoryViewModelParameters>(new DirectoryViewModelParameters(directory.Id));
        }

        private Task OpenFile(FileModel file)
        {
            return Task.CompletedTask;
        }

        private void FillDirectoryItems()
        {
            DirectoryItems.Clear();

            var items = _directory.Directories
                .Select<DirectoryDto, FileSystemElementModel>(d => DirectoryModel.Create(d))
                .Union(_directory.Files.Select(f => FileModel.Create(f)));

            foreach (var item in items)
            {
                DirectoryItems.Add(item);
            }
        }

        private async Task LoadDirectory()
        {

            var loadedDirectory = await LoadDirectory(GetNavigationParameters<DirectoryViewModelParameters>());
            if (loadedDirectory == null)
                throw new NullReferenceException(nameof(loadedDirectory));

            _directory = loadedDirectory;
        }

        private async Task<DirectoryDto> LoadDirectory(DirectoryViewModelParameters viewModelParameters)
        {
            if (viewModelParameters != null)
                return await _directoryRepository.GetDirectory(viewModelParameters.DirectoryId);

            return await _directoryRepository.GetDirectory(_drive.RootDirectoryId);
        }

        private async Task LoadDrive()
        {
            var user = await _authenticationService.GetUser();
            if (user == null)
                throw new NullReferenceException("Invalid get user");

            var loadedDrive = await _driveRepository.GetDrive(user.Id);
            if (loadedDrive == null)
                throw new NullReferenceException($"Invalid load drive by userId = {user.Id}");

            _drive = loadedDrive;
            Drive = DriveModel.Create(loadedDrive);
        }
    }
}
