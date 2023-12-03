using Amptron.Helpers;
using Amptron.Services.Interfaces;
using Amptron.ViewModels;
using Amptron.Views;
using Amptron.Views.Onboarding;

namespace Amptron;

public partial class App : Application
{
    #region Properties
    public static new IServiceProvider Current =>
#if ANDROID
     MauiApplication.Current.Services;
#else
            MauiUIApplicationDelegate.Current.Services;
#endif
    #endregion

    public App()
	{
		InitializeComponent();

        Task.Run(async () => await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            if (AppSettings.IsLogin)
            {
                //await Current.GetService<INavigationService>().SwitchTabs(typeof(HomePage));
            }
            else
            {
                await Current.GetService<INavigationService>().NavigateToAsync<OnboardingViewModel>(typeof(OnboardingPage), isRootPage: true);
            }
        }));
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        MainPage = new NavigationPage(new SplashScreenPage());
        return base.CreateWindow(activationState);
    }
}

