using System;
using Amptron.ViewModels.CustomViews;

namespace Amptron.ViewModels.Menu
{
	public partial class AboutUsViewModel:TabViewModelBase
	{
        public override async Task InitializeAsync(Dictionary<string, object> parameters)
        {
            BottomTabViewModel.SetSelectedTabImageAndLabel(3);
            await base.InitializeAsync(parameters);
        }
    }
}

