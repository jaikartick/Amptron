using Amptron.ViewModels.Menu;

namespace Amptron.Views.Menu;

public partial class AddDevicePage : ContentPage
{
	public AddDevicePage()
	{
		InitializeComponent();
	}

    void BorderlessEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (BindingContext is AddDeviceViewModel viewModel)
        {
            viewModel.FilterDeviceCommand.Execute(e.NewTextValue);
        }
    }
}
