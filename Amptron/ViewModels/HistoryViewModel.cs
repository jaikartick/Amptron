using System;
using Microcharts;
using SkiaSharp;

namespace Amptron.ViewModels
{
	public partial class HistoryViewModel:ViewModelBase
	{
        [ObservableProperty]
        private ObservableCollection<ChartEntry> entries;

        [ObservableProperty]
        private Dictionary<string, float> points;

        [ObservableProperty]
        private BarChart chart1;

        public HistoryViewModel()
		{
            Entries = new ObservableCollection<ChartEntry>
             {
                 new ChartEntry(12)
                 {
                     Label = "10 17:57",
                     ValueLabel = "12",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(2)
                 {
                     ValueLabel = "2",
                     Color = SKColor.Parse("#EEC006")
                 },
                 new ChartEntry(13)
                 {
                     Label = "10 17:57",
                     ValueLabel = "13",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(0)
                 {
                     ValueLabel = "0",
                     Color = SKColor.Parse("#EEC006")
                 },
                 new ChartEntry(12)
                 {
                     Label = "10 17.56",
                     ValueLabel = "12",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(1)
                 {
                     ValueLabel = "1",
                     Color = SKColor.Parse("#EEC006")
                 },
                 new ChartEntry(10)
                 {
                     Label = "10 17.56",
                     ValueLabel = "10",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(1)
                 {
                     ValueLabel = "1",
                     Color = SKColor.Parse("#EEC006")
                 },
                 new ChartEntry(12)
                 {
                     Label = "10 17.55",
                     ValueLabel = "12",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(0)
                 {
                     ValueLabel = "0",
                     Color = SKColor.Parse("#EEC006")
                 },
                 new ChartEntry(8)
                 {
                     Label = "10 17.55",
                     ValueLabel = "8",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(0)
                 {
                     ValueLabel = "0",
                     Color = SKColor.Parse("#EEC006")
                 },
                 new ChartEntry(7)
                 {
                     Label = "10 17.54",
                     ValueLabel = "7",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(6)
                 {
                     Label = "10 17.54",
                     ValueLabel = "6",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(5)
                 {
                     Label = "10 17.53",
                     ValueLabel = "5",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(10)
                 {
                     Label = "10 17.53",
                     ValueLabel = "10",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(15)
                 {
                     Label = "10 17.52",
                     ValueLabel = "15",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(13)
                 {
                     Label = "10 17.52",
                     ValueLabel = "13",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(8)
                 {
                     Label = "10 17.51",
                     ValueLabel = "8",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(11)
                 {
                     Label = "10 17.51",
                     ValueLabel = "11",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(15)
                 {
                     Label = "10 17.50",
                     ValueLabel = "15",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(10)
                 {
                     Label = "10 17.50",
                     ValueLabel = "10",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(9)
                 {
                     Label = "10 17.50",
                     ValueLabel = "9",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(10)
                 {
                     Label = "10 17.49",
                     ValueLabel = "10",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(11)
                 {
                     Label = "10 17.49",
                     ValueLabel = "11",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(14)
                 {
                     Label = "10 17.48",
                     ValueLabel = "14",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(14)
                 {
                     Label = "10 17.48",
                     ValueLabel = "14",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(15)
                 {
                     Label = "10 17.47",
                     ValueLabel = "15",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(15)
                 {
                     Label = "10 17.47",
                     ValueLabel = "15",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(8)
                 {
                     Label = "10 17.46",
                     ValueLabel = "8",
                     Color = SKColor.Parse("#3A55EC")
                 },
                 new ChartEntry(11)
                 {
                     Label = "10 17.46",
                     ValueLabel = "11",
                     Color = SKColor.Parse("#3A55EC")
                 }
            };
            Chart1 = new BarChart() { Entries = entries };

            Points = new Dictionary<string, float>()
            {
                {"Apples",25},
                {"Bananas",13},
                {"Strawberries",25},
                {"Blueberries", 53},
                {"Oranges", 14},
                {"Grapes", 52},
                {"Watermelons", 15},
                {"Pears",34 },
                {"Cantalopes", 67},
                {"Citrus",53 },
                {"Starfruit", 43},
                {"Papaya", 22},
                {"Papassya", 22},
            };
        }

    }
}

