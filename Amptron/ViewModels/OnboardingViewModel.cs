using System;
using Amptron.ViewModels.Menu;
using Amptron.Views;
using Amptron.Views.Menu;

namespace Amptron.ViewModels
{
	public partial class OnboardingViewModel:ViewModelBase
	{
        public ObservableCollection<int> CarouselItems { get; set; } = new ObservableCollection<int>() { 1, 2 };


        [RelayCommand]
        private async Task NavigateToHomePage()
        {
            await NavigationService.NavigateToAsync<DashboardViewModel>(typeof(DashboardPage));
        }

        [RelayCommand]
        private async Task NavigateToFaq()
        {
            await NavigationService.NavigateToAsync<FaqViewModel>(typeof(FaqPage));
        }

        [RelayCommand]
        private async Task NavigateToContactUs()
        {
            await NavigationService.NavigateToAsync<ContactUsViewModel>(typeof(ContactUsPage));
        }
    }
}

