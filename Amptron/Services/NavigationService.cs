using System;
using Amptron.Controls;
using Amptron.Helpers;
using Amptron.Services.Interfaces;
using Amptron.ViewModels;
using Amptron.ViewModels.Menu;
using Amptron.Views.Menu;

namespace Amptron.Services
{
    public class NavigationService : INavigationService
    {
        private static Dictionary<string, object> _onAppearingParameters;

        private static DashboardPage dashboardTab;
        private static DetailPage detailTab;
        private static DeviceInfoPage deviceInfoTab;
        private static AboutUsPage aboutUsTab;
        private static DeviceListPage deviceListTab;

        public ViewModelBase PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as ViewModelBase;
            }
        }

        #region Navigation Helpers


        public TViewModel GetViewModelOfPageInNavStack<TViewModel>(Type destinationPage) where TViewModel : ViewModelBase
        {

            TViewModel vm = null;
            var mainPage = Application.Current.MainPage;

            foreach (var page in mainPage.Navigation.NavigationStack)
            {
                if (page.GetType().Equals(destinationPage))
                {
                    vm = (TViewModel)page.BindingContext;
                    break;
                }

            }
            return vm;
        }


        public void RemovePagesTill(Type destinationPage, bool alsoPopAsync = false)
        {
            int leastFoundIndex = 0;
            int pagesToRemove = 0;
            var mainPage = Application.Current.MainPage;

            for (int index = mainPage.Navigation.NavigationStack.Count - 2; index > 0; index--)
            {
                if (mainPage.Navigation.NavigationStack[index].GetType().Equals(destinationPage))
                {
                    break;
                }
                else
                {
                    leastFoundIndex = index;
                    pagesToRemove++;
                }
            }

            for (int index = 0; index < pagesToRemove; index++)
            {
                mainPage.Navigation.RemovePage(mainPage.Navigation.NavigationStack[leastFoundIndex]);
            }
            if (alsoPopAsync)
            {
                mainPage.Navigation.PopAsync();
            }
        }
        public void ClearNavigationStack()
        {

            try
            {
                var mainPage = Application.Current.MainPage;
                if (mainPage != null)
                {
                    var existingPages = mainPage.Navigation.NavigationStack.ToList();

                    for (var i = 0; i <= existingPages.Count - 2; i++)
                    {
                        mainPage.Navigation.RemovePage(existingPages[i]);
                    }
                }

            }
            catch (Exception ex)
            {

            }


        }

        public Task NavigateToRootAsync()
        {
            var mainPage = Application.Current.MainPage;

            if (mainPage != null)
            {
                mainPage.Navigation.PopToRootAsync();
            }
            //homeTab = null;
            //categoryTab = null;
            //cartTab = null;
            //profileTab = null;

            return Task.FromResult(true);
        }

        public async Task NavigateToRootAsync(int index)
        {
            var mainPage = Application.Current.MainPage;

            if (mainPage != null)
            {
                await mainPage.Navigation.PopToRootAsync();
                if (mainPage is ExtendedTabbedPage extendedTabbedPage)
                {
                    extendedTabbedPage.CurrentPage = extendedTabbedPage.Children[index];
                }
            }
        }

        public Task RemoveLastFromBackStackAsync()
        {
            var mainPage = Application.Current.MainPage;

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }




        public Task InsertPageBefore<TViewModel>(Type pageType, Dictionary<string, object> parameters) where TViewModel : ViewModelBase
        {
            return InternalInsertPageBefore(typeof(TViewModel), pageType, parameters);
        }


        private static async Task InternalInsertPageBefore(Type viewModelType, Type pageType, Dictionary<string, object> parameters)
        {
            try
            {
                Page page = CreatePage(viewModelType, pageType);
                var navigationPage = Application.Current.MainPage;
                if (navigationPage != null)
                {
                    var lastPage = navigationPage.Navigation.NavigationStack.LastOrDefault();

                    navigationPage.Navigation.InsertPageBefore(page, lastPage);
                    // await (page.BindingContext as ViewModelBase).InitializeAsync(parameters);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        #region Navigate To Async
        public Task NavigateToAsync<TViewModel>(Type pageType, Dictionary<string, object> parameters, bool isRootPage = false) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), pageType, parameters, isRootPage);
        }

        public async Task SwitchTabs(Type pageType, Dictionary<string, object> parameters)
        {
            if (pageType == typeof(DashboardPage))
            {
                if (dashboardTab == null)
                {
                    dashboardTab = App.Current.GetService<DashboardPage>();
                    dashboardTab.BindingContext = App.Current.GetService<DashboardViewModel>();
                }
                await Application.Current.MainPage.Navigation.PushAsync(dashboardTab, false);
                await ((DashboardViewModel)dashboardTab.BindingContext).InitializeAsync(null);
            }
            else if (pageType == typeof(DetailPage))
            {
                if (detailTab == null)
                {
                    detailTab = App.Current.GetService<DetailPage>();
                    detailTab.BindingContext = App.Current.GetService<DetailViewModel>();
                }
                await Application.Current.MainPage.Navigation.PushAsync(detailTab, false);
                await ((DetailViewModel)detailTab.BindingContext).InitializeAsync(null);
            }
            else if (pageType == typeof(DeviceInfoPage))
            {
                if (deviceInfoTab == null)
                {
                    deviceInfoTab = App.Current.GetService<DeviceInfoPage>();
                    deviceInfoTab.BindingContext = App.Current.GetService<DeviceInfoViewModel>();
                }
                await Application.Current.MainPage.Navigation.PushAsync(deviceInfoTab, false);
                await ((DeviceInfoViewModel)deviceInfoTab.BindingContext).InitializeAsync(null);
            }
            else if (pageType == typeof(AboutUsPage))
            {
                if (aboutUsTab == null)
                {
                    aboutUsTab = App.Current.GetService<AboutUsPage>();
                    aboutUsTab.BindingContext = App.Current.GetService<AboutUsViewModel>();
                }
                await Application.Current.MainPage.Navigation.PushAsync(aboutUsTab, false);
                await ((AboutUsViewModel)aboutUsTab.BindingContext).InitializeAsync(null);
            }
            else if (pageType == typeof(DeviceListPage))
            {
                if (deviceListTab == null)
                {
                    deviceListTab = App.Current.GetService<DeviceListPage>();
                    deviceListTab.BindingContext = App.Current.GetService<DeviceListViewModel>();
                }
                await Application.Current.MainPage.Navigation.PushAsync(deviceListTab, false);
                await ((DeviceListViewModel)deviceListTab.BindingContext).InitializeAsync(null);
            }
        }

        #endregion

        #region Go Back
        public Task GoBackAsync(Dictionary<string, object> parameters = null)
        {
            var mainPage = Application.Current.MainPage;
            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }
            parameters.Add(NavigationKeys.IsBackNavigation, true);
            if (mainPage != null)
            {
                //if (mainPage.Navigation.ModalStack.Any())
                //{
                //    mainPage.Navigation.PopAsync(false);
                //    return Task.FromResult(true);
                //}

                if (mainPage.Navigation.NavigationStack.Any())
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        mainPage.Navigation.PopAsync();
                        var previousPage = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 1];
                        if (previousPage != null)
                        {
                            ((ViewModelBase)previousPage.BindingContext).InitializeAsync(parameters);
                        }
                    });
                }
            }

            return Task.FromResult(true);
        }

        #endregion

        #region Popup Navigate To Async
        public Task Popup_NavigateAsync<TViewModel>(Type page, Dictionary<string, object> parameters) where TViewModel : ViewModelBase
        {
            return InternalPopupNavigateAsync(typeof(TViewModel), page, parameters);
        }
        #endregion

        #region Navigate More Options
        public Task NavigateMoreOptionAsync<TViewModel>(Page page) where TViewModel : ViewModelBase
        {
            return InternalNavigateMoreOptionAsync(typeof(TViewModel), page);
        }

        #endregion

        #region Popup Navigate Go Back
        public Task Popup_GoBackAsync(Dictionary<string, object> parameters = null)
        {
            var mainPage = Application.Current.MainPage;
            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }
            parameters.Add(NavigationKeys.IsBackNavigation, true);
            if (mainPage != null)
            {
                if (mainPage.Navigation.ModalStack.Any())
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        mainPage.Navigation.PopModalAsync(false);
                        if (mainPage.Navigation.ModalStack.Any())
                        {
                            var previousModalPage = mainPage.Navigation.ModalStack[mainPage.Navigation.ModalStack.Count - 1];
                            if (previousModalPage != null)
                            {
                                ((ViewModelBase)previousModalPage.BindingContext).InitializeAsync(parameters);
                            }
                        }
                        else
                        {
                            var previousPage = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 1];
                            if (previousPage != null)
                            {
                                ((ViewModelBase)previousPage.BindingContext).InitializeAsync(parameters);
                            }
                        }
                    });
                    return Task.FromResult(true);
                }
            }

            return Task.FromResult(true);
        }

        #endregion

        #region Private Navigation Methods
        private static Page CreatePage(Type viewModelType, Type pageType)
        {
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {pageType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            page.BindingContext = DependencyService.Resolve(viewModelType);
            return page;
        }
        private static async Task InternalNavigateToAsync(Type viewModelType, Type pageType, Dictionary<string, object> parameters, bool isRootPage)
        {
            try
            {
                Page page = CreatePage(viewModelType, pageType);


                page.Appearing += PageOnAppearing;
                page.Disappearing += PageOnDisAppearing;
                if (parameters == null)
                {
                    parameters = new Dictionary<string, object>();
                }
                _onAppearingParameters = parameters;

                if (isRootPage)
                {
                    Application.Current.MainPage = new NavigationPage(page);
                    await (page.BindingContext as ViewModelBase).InitializeAsync(parameters);
                }
                else
                {
                    var navigationPage = Application.Current.MainPage;
                    if (navigationPage != null)
                    {
                        await navigationPage.Navigation.PushAsync(page, false);
                        await (page.BindingContext as ViewModelBase).InitializeAsync(parameters);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private static async void PageOnDisAppearing(object sender, EventArgs e)
        {
            try
            {
                var page = ((Page)sender);
                await (page.BindingContext as ViewModelBase).OnDisAppearing();
                page.Disappearing -= PageOnDisAppearing;

            }
            catch (Exception ex)
            {
            }
        }

        private static async void PageOnAppearing(object sender, EventArgs e)
        {
            try
            {
                var page = ((Page)sender);
                await (page.BindingContext as ViewModelBase).OnAppearing(_onAppearingParameters);
                page.Appearing -= PageOnAppearing;
            }
            catch (Exception ex)
            {
            }
        }
        private static async Task InternalPopupNavigateAsync(Type viewModelType, Type pageType, Dictionary<string, object> parameters)
        {
            Page page = CreatePage(viewModelType, pageType);
            page.Appearing += PageOnAppearing;
            page.Disappearing += PageOnDisAppearing;

            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }
            _onAppearingParameters = parameters;

            var navigationPage = Application.Current.MainPage;
            if (navigationPage != null)
            {
                await navigationPage.Navigation.PushModalAsync(page, false);

                await (page.BindingContext as ViewModelBase).InitializeAsync(parameters);
            }
            else
            {
            }
        }
        private static async Task InternalNavigateMoreOptionAsync(Type viewModelType, Page page)
        {
            page.BindingContext = DependencyService.Resolve(viewModelType);


            var navigationPage = Application.Current.MainPage;
            if (navigationPage != null)
            {
                await navigationPage.Navigation.PushModalAsync(page, false);
                await (page.BindingContext as ViewModelBase).InitializeAsync(null);
            }
            else
            {
            }
        }
        #endregion
    }
}

