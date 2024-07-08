using Amptron.ViewModels;
using Microcharts;

namespace Amptron.Views;

public partial class HistoryPage : ContentPage
{
	public HistoryPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //if(BindingContext is HistoryViewModel viewModel)
        //{
        //    var barChart = new BarChart() { Entries = viewModel.Entries };
        //}
    }
}
