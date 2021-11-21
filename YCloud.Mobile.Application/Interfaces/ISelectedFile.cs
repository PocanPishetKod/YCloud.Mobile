using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace YCloud.Mobile.Application.Interfaces
{
    public interface ISelectedFile
    {
        string Name { get; }

        Task<Stream> OpenRead();
    }
}
