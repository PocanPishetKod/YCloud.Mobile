using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Application.ViewModels;
using YCloud.Mobile.Navigation.NavigationAlgorithms;

namespace YCloud.Mobile.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly RegisteredPagesInformation _registeredPagesInformation;
        private readonly INavigationAlgorithmFactory _navigationAlgorithmFactory;

        public NavigationService(IServiceProvider serviceProvider, INavigationAlgorithmFactory navigationAlgorithmFactory)
        {
            _registeredPagesInformation = RegisteredPagesInformationProvider.Provide();
            _navigationAlgorithmFactory = navigationAlgorithmFactory;
        }

        public async Task Navigate<TViewModel>() where TViewModel : ViewModelBase
        {
            await GetNavigationAlgorithm(typeof(TViewModel), null).Navigate();
        }

        public async Task Navigate<TViewModel, TNavigationParameters>(TNavigationParameters parameters)
            where TViewModel : ViewModelBase
            where TNavigationParameters : class
        {
            await GetNavigationAlgorithm(typeof(TViewModel), parameters).Navigate();
        }

        public async Task NavigateToRoot()
        {
            await GetNavigationAlgorithm(null, null).Navigate();
        }

        public async Task NavigatieRoot<TNavigationParameters>(TNavigationParameters parameters) where TNavigationParameters : class
        {
            await GetNavigationAlgorithm(null, parameters).Navigate(); 
        }

        private NavigationAlgorithm GetNavigationAlgorithm(Type viewModelType, object navigationParameters)
        {
            var navigationPageInfo = viewModelType != null ? _registeredPagesInformation.Get(viewModelType) : _registeredPagesInformation.GetRoot();
            if (navigationPageInfo == null)
                throw new NullReferenceException($"Page information for {viewModelType.FullName} not found");

            return _navigationAlgorithmFactory.Create(navigationPageInfo, navigationParameters);
        }
    }
}
