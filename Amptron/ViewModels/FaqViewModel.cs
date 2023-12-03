using System;
using Amptron.Models;
using Amptron.Views;

namespace Amptron.ViewModels
{
	public partial class FaqViewModel:ViewModelBase
	{
        public ObservableCollection<FaqDataModel> FaqCollection { get; set; }

        [RelayCommand]
        private async Task NavigateSubmitQuestion()
        {
            await NavigationService.NavigateToAsync<SubmitQuestionViewModel>(typeof(SubmitQuestionPage));
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

        public override async Task InitializeAsync(Dictionary<string, object> parameters)
        {
            await base.InitializeAsync(parameters);
            var list = new List<FaqDataModel>()
            {
                new FaqDataModel() { Question = "This is first question", Answer = "First Answer" },
                new FaqDataModel() { Question = "This is second question", Answer = "Second Answer" },
                new FaqDataModel() { Question = "This is third question", Answer = "Third Answer" },
                new FaqDataModel() { Question = "This is fourth question", Answer = "Fourth Answer" },
                new FaqDataModel() { Question = "This is fifth question", Answer = "Fifth Answer" }
            };
            FaqCollection = new ObservableCollection<FaqDataModel>(list);
        }
    }
}

