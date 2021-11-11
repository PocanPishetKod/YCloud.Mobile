using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.ViewModels;

namespace YCloud.Mobile.Application.Interfaces
{
    public interface INavigationService
    {
        Task Navigate<T>() where T : ViewModelBase;

        Task NavigateToRoot();
    }
}
