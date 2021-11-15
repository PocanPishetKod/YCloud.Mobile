using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YCloud.Mobile.Navigation
{
    public class NavigatorWrapper
    {
        private readonly NavigationPage _navigationPage;

        public IReadOnlyList<Page> NavigationStack => _navigationPage.Navigation.NavigationStack;

        public IReadOnlyList<Page> ModalStack => _navigationPage.Navigation.ModalStack;

        public bool HasRootPage => _navigationPage.RootPage != null;

        public NavigatorWrapper(NavigationPage navigationPage)
        {
            _navigationPage = navigationPage;
        }

        public async Task PushAsync(Page page)
        {
            await _navigationPage.Navigation.PushAsync(page, true); 
        }

        public async Task PopAsync()
        {
            await _navigationPage.Navigation.PopAsync(true);
        }

        public async Task PushModalAsync(Page page)
        {
            await _navigationPage.Navigation.PushModalAsync(page, true);
        }

        public async Task PopModalAsync()
        {
            await _navigationPage.Navigation.PopModalAsync(true);
        }

        public async Task PopAllModalsAsync()
        {
            while (ModalStack.Count > 0)
            {
                await PopModalAsync();
            }
        }

        public async Task PopToRootAsync()
        {
            if (ModalStack.Count > 0)
                await PopAllModalsAsync();

            await _navigationPage.Navigation.PopToRootAsync(true);
        }

        public async Task SetRootPage(Page page)
        {
            if (_navigationPage.RootPage != null)
                throw new InvalidOperationException("Root page already set");

            await PushAsync(page);
        }
    }
}
