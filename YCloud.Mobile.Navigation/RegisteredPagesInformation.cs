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
            var targets = PageInfos.Where(p => p.ViewModelType == viewModelType).ToList();
            if (targets.Count == 0)
                return null;

            if (targets.Count == 1)
                return targets[0];

            return targets.OfType<PageInfo>().FirstOrDefault(p => !p.IsRoot);
        }

        public NavigationPageInfo GetRoot()
        {
            return PageInfos.OfType<PageInfo>().FirstOrDefault(p => p.IsRoot);
        }
    }
}
