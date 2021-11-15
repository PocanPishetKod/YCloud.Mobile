using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YCloud.Mobile.Navigation.NavigationAlgorithms
{
    public class ModalPageNavigationAlgorithm : NavigationAlgorithm
    {
        private readonly NavigatorWrapper _navigatorWrapper;

        public ModalPageNavigationAlgorithm(IServiceProvider serviceProvider, ModalPageInfo modalPageInfo,
            object navigationParameters, NavigatorWrapper navigatorWrapper)
            : base(serviceProvider, modalPageInfo, navigationParameters)
        {
            _navigatorWrapper = navigatorWrapper;
        }

        public override async Task Navigate()
        {
            if (_navigatorWrapper.ModalStack.Count > 0)
                await _navigatorWrapper.PopAllModalsAsync();

            await _navigatorWrapper.PushModalAsync(CreatePage());
        }
    }
}
