using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using YCloud.Mobile.Application.Models;

namespace YCloud.Mobile.ValueConverters
{
    public class DriveModelToDriveSpaceInfoConverter : IValueConverter
    {
        private const long OneGB = (long)1024 * 1024 * 1024;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var driveModel = value as DriveModel;
            if (driveModel == null)
                throw new ArgumentException($"Invalid value type. Actual type is {value.GetType().FullName}");

            return $"Total space: {ConvertBytesToString(driveModel.MaxSize)} | Avialable space: {ConvertBytesToString(driveModel.MaxSize - driveModel.Size)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string ConvertBytesToString(long bytes)
        {
            if (bytes >= OneGB)
                return $"{Math.Round((double)bytes / 1024 / 1024, 1)}GB";
            else
                return $"{bytes / 1024}MB";
        }
    }
}
