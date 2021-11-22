using System;
using System.Collections.Generic;
using System.Text;
using YCloud.Mobile.Application.Models;

namespace YCloud.Mobile.Application.NavigationParameters
{
    public class ImagesNavigationParameters
    {
        public IReadOnlyCollection<FileModel> ImageFiles { get; }

        public FileModel CurrentImage { get; }

        public ImagesNavigationParameters(IReadOnlyCollection<FileModel> imageFiles, FileModel currentImage)
        {
            ImageFiles = imageFiles ?? throw new ArgumentNullException(nameof(imageFiles));
            CurrentImage = currentImage ?? throw new ArgumentNullException(nameof(currentImage));
        }
    }
}
