using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using YCloud.Mobile.Application.Interfaces;

namespace YCloud.Mobile.Implementation
{
    public class SelectedFile : ISelectedFile
    {
        private readonly FileResult _fileResult;

        public string Name => _fileResult.FileName;

        public SelectedFile(FileResult fileResult)
        {
            _fileResult = fileResult ?? throw new ArgumentNullException(nameof(fileResult));
        }

        public async Task<Stream> OpenRead()
        {
            return await _fileResult.OpenReadAsync();
        }
    }
}
