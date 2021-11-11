using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Application.ViewModels;
using YCloud.Mobile.Pages.Directory;
using YCloud.Mobile.Pages.SignIn;
using YCloud.Mobile.Pages.SignUp;

namespace YCloud.Mobile.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly NavigatorWrapper _navigationWrapper;
        private static readonly Dictionary<Type, Type> _pageTypes;
        private static readonly Dictionary<Type, Type> _modalPageTypes;
        private static readonly Dictionary<Type, Type> _rootPageType;

        static NavigationService()
        {
            _pageTypes = new Dictionary<Type, Type>()
            {
                { typeof(DirectoryViewModel), typeof(DirectoryPage) }
            };

            _modalPageTypes = new Dictionary<Type, Type>()
            {
                { typeof(SignInViewModel), typeof(SignInPage)  },
                { typeof(SignUpViewModel), typeof(SignUpPage) }
            };

            _rootPageType = new Dictionary<Type, Type>()
            {
                { typeof(DirectoryViewModel), typeof(DirectoryPage) }
            };
        }

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _navigationWrapper = new NavigatorWrapper(App.Current.MainPage as NavigationPage);
        }

        public async Task Navigate<T>() where T : ViewModelBase
        {
            if (_pageTypes.TryGetValue(typeof(T), out var pageType))
            {
                await _navigationWrapper.PushAsync(GetPage<T>(pageType));
            }
            else if (_modalPageTypes.TryGetValue(typeof(T),out var modalPageType))
            {
                if (_navigationWrapper.ModalStack.Count > 0)
                    await _navigationWrapper.PopAllModalsAsync();

                await _navigationWrapper.PushModalAsync(GetPage<T>(modalPageType));
            }
            else
            {
                throw new InvalidOperationException($"Navigation page for {typeof(T).FullName} not found");
            }
        }

        public async Task NavigateToRoot()
        {
            if (!_navigationWrapper.HasRootPage)
                await _navigationWrapper.SetRootPage(GetPage(_rootPageType.First().Value, _rootPageType.First().Key));

            await _navigationWrapper.PopToRootAsync();
        }

        private Page GetPage<T>(Type pageType) where T : ViewModelBase
        {
            return Activator.CreateInstance(pageType, _serviceProvider.GetService(typeof(T))) as Page;
        }

        private Page GetPage(Type pageType, Type viewModelType)
        {
            return Activator.CreateInstance(pageType, _serviceProvider.GetService(viewModelType)) as Page;
        }
    }
}
