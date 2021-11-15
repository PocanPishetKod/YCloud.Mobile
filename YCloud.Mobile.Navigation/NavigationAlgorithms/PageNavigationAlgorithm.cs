using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YCloud.Mobile.Application.ViewModels;

namespace YCloud.Mobile.Navigation
{
    public class PageNavigationAlgorithm : NavigationAlgorithm
    {
        private readonly NavigatorWrapper _navigationWrapper;
        private readonly PageInfo _pageInfo;

        public PageNavigationAlgorithm(IServiceProvider serviceProvider, PageInfo pageInfo, object navigationParameters,
            NavigatorWrapper navigatorWrapper)
            : base(serviceProvider, pageInfo, navigationParameters)
        {
            _navigationWrapper = navigatorWrapper;
            _pageInfo = pageInfo;
        }

        public override async Task Navigate()
        {
            if (_pageInfo.IsRoot)
            {
                if (!_navigationWrapper.HasRootPage)
                    await _navigationWrapper.SetRootPage(CreatePage());

                if (_navigationWrapper.ModalStack.Count > 0)
                    await _navigationWrapper.PopAllModalsAsync();

                await _navigationWrapper.PopToRootAsync();
            }
            else
            {
                if (_navigationWrapper.ModalStack.Count > 0)
                    await _navigationWrapper.PopAllModalsAsync();

                await _navigationWrapper.PushAsync(CreatePage());
            }
        }
    }
}
