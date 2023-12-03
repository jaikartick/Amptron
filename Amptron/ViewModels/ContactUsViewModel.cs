using System;
namespace Amptron.ViewModels
{
	public partial class ContactUsViewModel:ViewModelBase
	{
        public string Email { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }

        [RelayCommand]
        private async Task SubmitForm()
        {

        }
    }
}

