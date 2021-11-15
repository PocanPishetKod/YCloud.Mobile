using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Navigation
{
    public class PageInfo : NavigationPageInfo
    {
        public bool IsRoot { get; }

        public PageInfo(Type pageType, Type viewModelType) : base(pageType, viewModelType)
        {

        }

        public PageInfo(Type pageType, Type viewModelType, bool isRoot) : this(pageType, viewModelType)
        {
            IsRoot = isRoot;
        }
    }
}
