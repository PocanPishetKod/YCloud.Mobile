using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using YCloud.Mobile.Application.Interfaces;
using YCloud.Mobile.Application.ViewModels;
using YCloud.Mobile.Authentication;
using YCloud.Mobile.Data.Repositories;
using YCloud.Mobile.Navigation;
using YCloud.Mobile.Navigation.NavigationAlgorithms;

namespace YCloud.Mobile.Initialization
{
    public abstract class ServiceProviderBuilder
    {
        public virtual IServiceProvider Build()
        {
            var serviceCollection = new ServiceCollection();
            AddViewModels(serviceCollection);
            AddServices(serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }

        private void AddViewModels(ServiceCollection services)
        {
            services.AddTransient<ApplicationViewModel>();
            services.AddTransient<DirectoryViewModel>();
            services.AddTransient<SignInViewModel>();
            services.AddTransient<SignUpViewModel>();
        }

        private void AddServices(ServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<INavigationAlgorithmFactory, NavigarionAlgorithmFactory>();
            services.AddSingleton<IDirectoryRepository, DirectoryRepository>();
            services.AddSingleton<IDriveRepository, DriveRepository>();
            services.AddSingleton<IFileRepository, FileRepository>();
        }
    }
}
