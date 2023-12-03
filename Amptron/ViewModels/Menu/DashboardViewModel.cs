using System;
using Amptron.ViewModels.CustomViews;
using Amptron.Views;

namespace Amptron.ViewModels.Menu
{
	public partial class DashboardViewModel:TabViewModelBase
	{
        public double Power { get; set; }
        public double Current { get; set; }
        public double Voltage { get; set; }
        public string Status { get; set; }
        public double SocPercentage { get; set; }

        public double RatedCapacity { get; set; }
        public double RemainingCapacity { get; set; }
        public string PowerUpdatedStatus { get; set; }
        public string CurrentUpdatedStatus { get; set; }
        public string VoltageUpdatedStatus { get; set; }
        public string StatusUpdatedStatus { get; set; }

        public DashboardViewModel()
        {
            //Power = 0.00;
            PowerUpdatedStatus = "Just Updated";

            Current = 0.00;
            CurrentUpdatedStatus = "Just Updated";

            Voltage = 0.00;
            VoltageUpdatedStatus = "Just Updated";

            Status = "Standby";
            StatusUpdatedStatus = "Just Updated";

            SocPercentage = 70;

            RatedCapacity = 700;
            RemainingCapacity = 300;
        }

        public override async Task InitializeAsync(Dictionary<string, object> parameters)
        {
            BottomTabViewModel.SetSelectedTabImageAndLabel(0);
            await base.InitializeAsync(parameters);
        }

        [RelayCommand]
        private void NavigateToAlarm()
        {
            NavigationService.NavigateToAsync<AlarmViewModel>(typeof(AlarmPage));
        }

        [RelayCommand]
        private void NavigateToFaq()
        {
            NavigationService.NavigateToAsync<FaqViewModel>(typeof(FaqPage));
        }

        [RelayCommand]
        private void NavigateToContactUs()
        {
            NavigationService.NavigateToAsync<ContactUsViewModel>(typeof(ContactUsPage));
        }
    }
}

