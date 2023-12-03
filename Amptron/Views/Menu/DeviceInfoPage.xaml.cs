using Amptron.ViewModels.Menu;

namespace Amptron.Views.Menu;

public partial class DeviceInfoPage : ContentPage
{
	public DeviceInfoPage()
	{
		InitializeComponent();
	}

    void Entry_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
    }

    void Entry_Unfocused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        if (BindingContext is DeviceInfoViewModel viewModel)
        {
            viewModel.IsEditName = false;
        }
    }
}
