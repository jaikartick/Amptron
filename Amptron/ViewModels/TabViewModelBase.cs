using System;
using Amptron.ViewModels.CustomViews;

namespace Amptron.ViewModels
{
	public partial class TabViewModelBase:ViewModelBase
    {
        [ObservableProperty]
        private BottomTabViewModel bottomTabViewModel;

        public TabViewModelBase()
        {
            BottomTabViewModel = App.Current.GetService<BottomTabViewModel>();
        }

        public override async Task InitializeAsync(Dictionary<string, object> parameters)
        {
            await base.InitializeAsync(parameters);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}

