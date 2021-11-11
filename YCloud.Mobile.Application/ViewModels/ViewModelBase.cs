using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Interfaces;

namespace YCloud.Mobile.Application.ViewModels
{
    public class ViewModelBase
    {
        protected readonly INavigationService _navigationService;

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected async Task Navigate<T>() where T : ViewModelBase
        {
            await _navigationService.Navigate<T>();
        }
    }
}
