using System;
using Amptron.Views;
using Amptron.Views.Menu;

namespace Amptron.ViewModels.CustomViews
{
    public partial class BottomTabViewModel : ViewModelBase
    {
        #region Properties
        [ObservableProperty]
        private int _selectedIndex = 0;

        public BottomTabViewModel()
        {
            SelectedIndex = 0;
            SelectedOne = true;

            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                HeightRequest = 60;
            }
            else
            {

#if IOS
                if (Amptron.Platforms.iOS.IOSHelper.IsLowerThanIphoneX())
                {
                    HeightRequest = 60;
                }
                else
                {
                    HeightRequest = 40;
                }
#endif
            }

        }

        [ObservableProperty]
        public bool _selectedOne;

        [ObservableProperty]
        public bool _selectedTwo;

        [ObservableProperty]
        public bool _selectedThree;

        [ObservableProperty]
        public bool _selectedFour;

        [ObservableProperty]
        public bool _selectedFive;

        [ObservableProperty]
        public double _heightRequest = 60;

        #endregion

        public override async Task InitializeAsync(Dictionary<string, object> parameters)
        {
            await base.InitializeAsync(parameters);
        }

        #region Commands
        private RelayCommand<object> _tabCommand;
        public RelayCommand<object> TabCommand => _tabCommand ?? (_tabCommand = new RelayCommand<object>(ExecuteTabCommand));

        private async void ExecuteTabCommand(object obj)
        {
            await ExecuteTabInternal(obj, null);
        }
        #endregion



        public async Task ExecuteTabInternal(object obj, Dictionary<string, object> navParams)
        {
            try
            {
                SelectedIndex = Convert.ToInt32(obj);

                SetSelectedTabImageAndLabel(SelectedIndex);

                var navigation = Application.Current.MainPage.Navigation;
                var pageList = navigation.NavigationStack.ToList();

                switch (SelectedIndex)
                {
                    case 0:
                        if (navigation.NavigationStack.Last() is DashboardPage)
                            return;

                        foreach (var page in pageList)
                        {
                            if (page is DashboardPage)
                            {
                                navigation.RemovePage(page);
                                break;
                            }
                        }

                        await NavigationService.SwitchTabs(typeof(DashboardPage));

                        break;

                    case 1:

                        if (navigation.NavigationStack.Last() is DetailPage)
                            return;

                        foreach (var page in pageList)
                        {
                            if (page is DetailPage)
                            {
                                navigation.RemovePage(page);
                                break;
                            }
                        }
                        await NavigationService.SwitchTabs(typeof(DetailPage));

                        break;

                    case 2:

                        if (navigation.NavigationStack.Last() is DeviceInfoPage)
                            return;

                        foreach (var page in pageList)
                        {
                            if (page is DeviceInfoPage)
                            {
                                navigation.RemovePage(page);
                                break;
                            }
                        }
                        await NavigationService.SwitchTabs(typeof(DeviceInfoPage));

                        break;

                    case 3:
                        if (navigation.NavigationStack.Last() is AboutUsPage)
                            return;

                        foreach (var page in pageList)
                        {
                            if (page is AboutUsPage)
                            {
                                navigation.RemovePage(page);
                                break;
                            }
                        }
                        await NavigationService.SwitchTabs(typeof(AboutUsPage));

                        break;

                    case 4:
                        if (navigation.NavigationStack.Last() is DeviceListPage)
                            return;

                        foreach (var page in pageList)
                        {
                            if (page is DeviceListPage)
                            {
                                navigation.RemovePage(page);
                                break;
                            }
                        }
                        await NavigationService.SwitchTabs(typeof(DeviceListPage));

                        break;

                }
            }
            catch (Exception ex)
            {
                //TelemetryHelper.TrackException(GetType().Name, nameof(ExecuteTabCommand), ex);
            }
        }

        public void SetSelectedTabImageAndLabel(int index)
        {
            SelectedIndex = index;
            switch (index)
            {
                case 0:
                    SelectedOne = true;
                    SelectedTwo = false;
                    SelectedThree = false;
                    SelectedFour = false;
                    SelectedFive = false;
                    break;

                case 1:
                    SelectedOne = false;
                    SelectedTwo = true;
                    SelectedThree = false;
                    SelectedFour = false;
                    SelectedFive = false;
                    break;

                case 2:
                    SelectedOne = false;
                    SelectedTwo = false;
                    SelectedThree = true;
                    SelectedFour = false;
                    SelectedFive = false;
                    break;

                case 3:
                    SelectedOne = false;
                    SelectedTwo = false;
                    SelectedThree = false;
                    SelectedFour = true;
                    SelectedFive = false;
                    break;

                case 4:
                    SelectedOne = false;
                    SelectedTwo = false;
                    SelectedThree = false;
                    SelectedFour = false;
                    SelectedFive = true;
                    break;
            }

        }
    }
}

