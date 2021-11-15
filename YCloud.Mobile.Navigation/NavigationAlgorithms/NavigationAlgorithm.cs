using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YCloud.Mobile.Application.ViewModels;

namespace YCloud.Mobile.Navigation
{
    public abstract class NavigationAlgorithm
    {
        private readonly NavigationPageInfo _navigationPageInfo;
        private readonly object _navigationParameters;
        private readonly IServiceProvider _serviceProvider;

        protected NavigationAlgorithm(IServiceProvider serviceProvider, NavigationPageInfo navigationPageInfo, object navigationParameters)
        {
            _navigationPageInfo = navigationPageInfo;
            _navigationParameters = navigationParameters;
            _serviceProvider = serviceProvider;
        }

        public abstract Task Navigate();

        protected Page CreatePage()
        {
            var viewModel = _serviceProvider.GetService(_navigationPageInfo.ViewModelType) as ViewModelBase;

            if (_navigationParameters != null)
                viewModel.SetNavigationParameters(_navigationParameters);

            return Activator.CreateInstance(_navigationPageInfo.PageType, viewModel) as Page;
        }
    }
}
