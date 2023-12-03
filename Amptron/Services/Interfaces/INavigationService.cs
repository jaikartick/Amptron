using System;
using Amptron.ViewModels;

namespace Amptron.Services.Interfaces
{
	public interface INavigationService
	{
        ViewModelBase PreviousPageViewModel { get; }
        Task NavigateToAsync<TViewModel>(Type pageType, Dictionary<string, object> parameters = null, bool isRootPage = false) where TViewModel : ViewModelBase;
        Task Popup_NavigateAsync<TViewModel>(Type page, Dictionary<string, object> parameters = null) where TViewModel : ViewModelBase;
        Task RemoveLastFromBackStackAsync();
        Task NavigateToRootAsync();
        Task NavigateToRootAsync(int index);
        Task GoBackAsync(Dictionary<string, object> parameters = null);
        Task Popup_GoBackAsync(Dictionary<string, object> parameters = null);

        Task NavigateMoreOptionAsync<TViewModel>(Page page) where TViewModel : ViewModelBase;

        void ClearNavigationStack();

        //TODO; SWitch Tab in NavigationService after Tab implementation
        Task SwitchTabs(Type pageType, Dictionary<string, object> parameters = null);
    }
}

