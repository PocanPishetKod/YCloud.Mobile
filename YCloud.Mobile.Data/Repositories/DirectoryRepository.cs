﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Dto;
using YCloud.Mobile.Application.Interfaces;

namespace YCloud.Mobile.Data.Repositories
{
    public class DirectoryRepository : IDirectoryRepository
    {
        public Task<DirectoryDto> GetDirectory(string id)
        {
            var result = new DirectoryDto()
            {
                Id = id,
                Name = "Directory",
                ParentDirectoryId = "ParentId",
                Size = 1024,
                Directories = new List<DirectoryDto>()
                {
                    new DirectoryDto()
                    {
                        Id = "Id",
                        Name = "Directory",
                        ParentDirectoryId = id,
                        Size = 1024
                    },
                    new DirectoryDto()
                    {
                        Id = "Id",
                        Name = "Directory",
                        ParentDirectoryId = id,
                        Size = 1024
                    },
                    new DirectoryDto()
                    {
                        Id = "Id",
                        Name = "Directory",
                        ParentDirectoryId = id,
                        Size = 1024
                    },
                    new DirectoryDto()
                    {
                        Id = "Id",
                        Name = "Directory",
                        ParentDirectoryId = id,
                        Size = 1024
                    }
                },
                Files = new List<FileDto>()
                {
                    new FileDto()
                    {
                        Id = "Id",
                        Name = "File",
                        DirectoryId = id,
                        Size = 1024
                    },
                    new FileDto()
                    {
                        Id = "Id",
                        Name = "File",
                        DirectoryId = id,
                        Size = 1024
                    },
                    new FileDto()
                    {
                        Id = "Id",
                        Name = "File",
                        DirectoryId = id,
                        Size = 1024
                    },
                    new FileDto()
                    {
                        Id = "Id",
                        Name = "File",
                        DirectoryId = id,
                        Size = 1024
                    },
                    new FileDto()
                    {
                        Id = "Id",
                        Name = "File",
                        DirectoryId = id,
                        Size = 1024
                    }
                }
            };

            return Task.FromResult(result);
        }
    }
}
