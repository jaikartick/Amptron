using System;
using Amptron.Services.Interfaces;
using Mopups.Interfaces;

namespace Amptron.ViewModels
{
    public partial class ViewModelBase : ObservableObject, IViewModelBase, IDisposable
    {
        private readonly SemaphoreSlim _isBusyLock = new(1, 1);

        private bool _isInitialized;
        private bool _disposedValue;
        private bool _isBusy;
        private bool _showUI;
        private bool _isAndroid;

        public INavigationService NavigationService { get; private set; }
        public IPopupNavigation PopupNavigation { get; private set; }
        //public ActivityIndicatorPopup ActivityIndicatorPopup { get; private set; }

        public bool IsInitialized
        {
            get => _isInitialized;
            set => SetProperty(ref _isInitialized, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public bool ShowUI
        {
            get => _showUI;
            set => SetProperty(ref _showUI, value);
        }
        public bool IsAndroid
        {
            get => _isAndroid;
            set => SetProperty(ref _isAndroid, value);
        }

        [ObservableProperty]
        private string _selectedLang;

        [RelayCommand]
        public async void NavigateBack()
        {
            await NavigationService.GoBackAsync();
        }

        public ViewModelBase()
        {
            PopupNavigation = App.Current.GetService<IPopupNavigation>();
            NavigationService = App.Current.GetService<INavigationService>();
            //ActivityIndicatorPopup = App.Current.GetService<ActivityIndicatorPopup>();
        }

        public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
        {
        }

        public virtual Task InitializeAsync(Dictionary<string, object> parameters)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnAppearing(Dictionary<string, object> parameters)
        {
            return Task.CompletedTask;
        }
        public virtual Task OnDisAppearing()
        {
            return Task.CompletedTask;
        }

        public async Task IsBusyFor(Func<Task> unitOfWork)
        {
            await _isBusyLock.WaitAsync();

            try
            {
                IsBusy = true;
                await unitOfWork();
            }
            catch (Exception ex)
            {
                await ShowExceptionAlert(ex);
            }
            finally
            {
                IsBusy = false;
                _isBusyLock.Release();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _isBusyLock?.Dispose();
                }

                _disposedValue = true;
            }
        }

        protected virtual async Task ShowExceptionAlert(Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
        }
        protected virtual async Task ShowExceptionAlert(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Error", message, "Ok");
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

