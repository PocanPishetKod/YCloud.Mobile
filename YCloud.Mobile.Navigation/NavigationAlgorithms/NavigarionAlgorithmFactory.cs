using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace YCloud.Mobile.Navigation.NavigationAlgorithms
{
    public class NavigarionAlgorithmFactory : INavigationAlgorithmFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly NavigatorWrapper _navigationWrapper;

        public NavigarionAlgorithmFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _navigationWrapper = new NavigatorWrapper(App.Current.MainPage as NavigationPage);
        }

        public NavigationAlgorithm Create(NavigationPageInfo navigationPageInfo)
        {
            return GetAlgorithm(navigationPageInfo);
        }

        public NavigationAlgorithm Create(NavigationPageInfo navigationPageInfo, object navigationParameters)
        {
            return GetAlgorithm(navigationPageInfo, navigationParameters);
        }

        private NavigationAlgorithm GetAlgorithm(NavigationPageInfo navigationPageInfo, object navigationParameters = null)
        {
            if (navigationPageInfo is PageInfo pageInfo)
            {
                return new PageNavigationAlgorithm(_serviceProvider, pageInfo, navigationParameters, _navigationWrapper);
            }
            else if (navigationPageInfo is ModalPageInfo modalPageInfo)
            {
                return new ModalPageNavigationAlgorithm(_serviceProvider, modalPageInfo, navigationParameters, _navigationWrapper);
            }
            else
            {
                throw new InvalidOperationException($"Navigation algorithm ({navigationPageInfo.GetType().FullName}) not found");
            }
        }
    }
}
