using System;
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
                        Name = "File.jpg",
                        DirectoryId = id,
                        Size = 1024
                    },
                    new FileDto()
                    {
                        Id = "Id",
                        Name = "File.jpg",
                        DirectoryId = id,
                        Size = 1024
                    },
                    new FileDto()
                    {
                        Id = "Id",
                        Name = "File.jpg",
                        DirectoryId = id,
                        Size = 1024
                    },
                    new FileDto()
                    {
                        Id = "Id",
                        Name = "File.jpg",
                        DirectoryId = id,
                        Size = 1024
                    },
                    new FileDto()
                    {
                        Id = "Id",
                        Name = "File.jpg",
                        DirectoryId = id,
                        Size = 1024
                    }
                }
            };

            return Task.FromResult(result);
        }

        public Task<DirectoryDto> Create(string directoryName, string parentDirectoryId, string driveId)
        {
            return Task.FromResult(new DirectoryDto()
            {
                Id = Guid.NewGuid().ToString(),
                Name = directoryName,
                Directories = new List<DirectoryDto>(),
                Files = new List<FileDto>(),
                ParentDirectoryId = parentDirectoryId,
                Size = 0
            });
        }

        public Task Delete(string id)
        {
            return Task.CompletedTask;
        }
    }
}
