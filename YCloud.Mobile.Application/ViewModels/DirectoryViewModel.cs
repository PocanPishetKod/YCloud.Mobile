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
        private readonly IFileRepository _fileRepository;

        private DirectoryDto _directoryDto;
        private DriveDto _driveDto;
        private DriveModel _drive;

        public ObservableCollection<FileSystemElementModel> DirectoryItems { get; private set; }

        public DriveModel Drive 
        {
            get => _drive;
            private set
            {
                _drive = value;
                NotifyPropertyChanged(nameof(Drive));
            }
        }

        public DirectoryViewModel(INavigationService navigationService, IDirectoryRepository directoryRepository,
            IAuthenticationService authenticationService, IDriveRepository driveRepository, IFileRepository fileRepository)
        {
            _navigationService = navigationService;
            _directoryRepository = directoryRepository;
            _authenticationService = authenticationService;
            _driveRepository = driveRepository;
            _fileRepository = fileRepository;
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

        public async Task CreateDirectory(string name)
        {

        }

        public async Task UploadFiles(IReadOnlyCollection<ISelectedFile> selectedFiles)
        {
            if (selectedFiles.Count == 0)
                return;

            var uploadedFiles = await _fileRepository.UploadFiles(selectedFiles, _directoryDto.Id, _driveDto.Id);
            foreach (var file in uploadedFiles)
            {
                DirectoryItems.Add(FileModel.Create(file));
            }

            await LoadDrive();
        }

        private Task OpenFile(FileModel file)
        {
            return Task.CompletedTask;
        }

        private void FillDirectoryItems()
        {
            DirectoryItems.Clear();

            var items = _directoryDto.Directories
                .Select<DirectoryDto, FileSystemElementModel>(d => DirectoryModel.Create(d))
                .Union(_directoryDto.Files.Select(f => FileModel.Create(f)));

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

            _directoryDto = loadedDirectory;
        }

        private async Task<DirectoryDto> LoadDirectory(DirectoryViewModelParameters viewModelParameters)
        {
            if (viewModelParameters != null)
                return await _directoryRepository.GetDirectory(viewModelParameters.DirectoryId);

            return await _directoryRepository.GetDirectory(_driveDto.RootDirectoryId);
        }

        private async Task LoadDrive()
        {
            var user = await _authenticationService.GetUser();
            if (user == null)
                throw new NullReferenceException("Invalid get user");

            var loadedDrive = await _driveRepository.GetDrive(user.Id);
            if (loadedDrive == null)
                throw new NullReferenceException($"Invalid load drive by userId = {user.Id}");

            _driveDto = loadedDrive;
            Drive = DriveModel.Create(loadedDrive);
        }
    }
}
