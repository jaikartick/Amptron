namespace Amptron.Views;

public partial class LoadingIndicatorPage : ContentPage
{
	public LoadingIndicatorPage()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}
