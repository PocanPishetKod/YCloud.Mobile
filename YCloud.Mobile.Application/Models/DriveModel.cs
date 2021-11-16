using System;
using System.Collections.Generic;
using System.Text;
using YCloud.Mobile.Application.Dto;

namespace YCloud.Mobile.Application.Models
{
    public class DriveModel
    {
        public string Id { get; }

        public long Size { get; set; }

        public long MaxSize { get; set; }

        private DriveModel(string id, long size, long maxSize)
        {
            Id = id;
            Size = size;
            MaxSize = maxSize;
        }

        public static DriveModel Create(DriveDto driveDto)
        {
            return new DriveModel(driveDto.Id, driveDto.Size, driveDto.MaxSize);
        }
    }
}
