using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using YCloud.Mobile.Application.ViewModels;

namespace YCloud.Mobile.Navigation
{
    public class RegisteredPagesInformation
    {
        public IReadOnlyCollection<NavigationPageInfo> PageInfos { get; }

        public RegisteredPagesInformation(IReadOnlyCollection<NavigationPageInfo> pageInfos)
        {
            PageInfos = pageInfos;
        }

        public NavigationPageInfo Get(Type viewModelType)
        {
            return PageInfos.FirstOrDefault(p => p.ViewModelType == viewModelType);
        }

        public NavigationPageInfo GetRoot()
        {
            return PageInfos.Cast<PageInfo>().FirstOrDefault(p => p.IsRoot);
        }
    }
}
