using System;
using Amptron.Services;
using Amptron.Services.Interfaces;
using Amptron.ViewModels;
using Amptron.ViewModels.CustomViews;
using Amptron.ViewModels.Menu;
using Amptron.Views;
using Amptron.Views.Menu;
using Amptron.Views.Onboarding;
using Mopups.Interfaces;
using Mopups.Services;

namespace Amptron.Helpers
{
    public static class CompositionRoot
    {
        public static IServiceCollection GetServices(IServiceCollection services)
        {
            services.AddTransient<MainPage, MainPage>();
            services.AddTransient<OnboardingPage, OnboardingPage>();
            services.AddTransient<LoginPage, LoginPage>();
            services.AddTransient<FaqPage, FaqPage>();
            services.AddTransient<SubmitQuestionPage, SubmitQuestionPage>();
            services.AddTransient<ContactUsPage, ContactUsPage>();
            services.AddTransient<DashboardPage, DashboardPage>();
            services.AddTransient<DetailPage, DetailPage>();
            services.AddTransient<DeviceListPage, DeviceListPage>();
            services.AddTransient<DeviceInfoPage, DeviceInfoPage>();
            services.AddTransient<AboutUsPage, AboutUsPage>();
            services.AddTransient<AlarmPage, AlarmPage>();
            services.AddTransient<AddDevicePage, AddDevicePage>();

            services.AddTransient<OnboardingViewModel, OnboardingViewModel>();
            services.AddTransient<LoginViewModel, LoginViewModel>();
            services.AddTransient<FaqViewModel, FaqViewModel>();
            services.AddTransient<SubmitQuestionViewModel, SubmitQuestionViewModel>();
            services.AddTransient<ContactUsViewModel, ContactUsViewModel>();
            services.AddTransient<DashboardViewModel, DashboardViewModel>();
            services.AddTransient<DeviceInfoViewModel, DeviceInfoViewModel>();
            services.AddTransient<DeviceListViewModel, DeviceListViewModel>();
            services.AddTransient<DetailViewModel, DetailViewModel>();
            services.AddTransient<AboutUsViewModel, AboutUsViewModel>();
            services.AddTransient<BottomTabViewModel, BottomTabViewModel>();
            services.AddTransient<AlarmViewModel, AlarmViewModel>();
            services.AddTransient<AddDeviceViewModel, AddDeviceViewModel>();

            #region Services
            services.AddSingleton<INavigationService, NavigationService>();
#if IOS
            //services.AddSingleton<ILoadingPageService, LoadingPageService>();
#endif
            services.AddSingleton<IPopupNavigation>(MopupService.Instance);
#endregion
            return services;

        }
    }
}

