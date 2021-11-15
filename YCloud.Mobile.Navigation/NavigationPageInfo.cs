using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Navigation
{
    public abstract class NavigationPageInfo
    {
        public Type PageType { get; }
        public Type ViewModelType { get; }

        protected NavigationPageInfo(Type pageType, Type viewModelType)
        {
            PageType = pageType;
            ViewModelType = viewModelType;
        }
    }
}
