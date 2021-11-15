using System;
using System.Collections.Generic;
using System.Text;
using YCloud.Mobile.Application.ViewModels;
using YCloud.Mobile.Pages.Directory;
using YCloud.Mobile.Pages.SignIn;
using YCloud.Mobile.Pages.SignUp;

namespace YCloud.Mobile.Navigation
{
    public static class RegisteredPagesInformationProvider
    {
        private static readonly Dictionary<Type, Type> _pageTypes;
        private static readonly Dictionary<Type, Type> _modalPageTypes;
        private static readonly KeyValuePair<Type, Type> _rootPageType;

        static RegisteredPagesInformationProvider()
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

            _rootPageType = new KeyValuePair<Type, Type>(typeof(DirectoryViewModel), typeof(DirectoryPage));
        }

        public static RegisteredPagesInformation Provide()
        {
            var pageTypes = new List<NavigationPageInfo>();
            foreach (var item in _pageTypes)
            {
                pageTypes.Add(new PageInfo(item.Value, item.Key));
            }

            foreach (var item in _modalPageTypes)
            {
                pageTypes.Add(new ModalPageInfo(item.Value, item.Key));
            }

            pageTypes.Add(new PageInfo(_rootPageType.Value, _rootPageType.Key));

            return new RegisteredPagesInformation(pageTypes);
        }
    }
}
