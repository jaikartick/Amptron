namespace Amptron.Views.Menu;

public partial class DeviceListPage : ContentPage
{
	public DeviceListPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.AddDevice.IsEnabled = true;
    }
}
