using System;
using System.Collections.Generic;
using System.Text;

namespace YCloud.Mobile.Navigation.NavigationAlgorithms
{
    public interface INavigationAlgorithmFactory
    {
        NavigationAlgorithm Create(NavigationPageInfo navigationPageInfo, object navigationParameters);

        NavigationAlgorithm Create(NavigationPageInfo navigationPageInfo);
    }
}
