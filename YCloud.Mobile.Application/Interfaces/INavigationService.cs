using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.ViewModels;

namespace YCloud.Mobile.Application.Interfaces
{
    public interface INavigationService
    {
        Task Navigate<TViewModel>() where TViewModel : ViewModelBase;

        Task Navigate<TViewModel, TNavigationParameters>(TNavigationParameters parameters) 
            where TViewModel : ViewModelBase where TNavigationParameters : class;

        Task NavigateToRoot();

        Task NavigatieRoot<TNavigationParameters>(TNavigationParameters parameters)
            where TNavigationParameters : class;
    }
}
