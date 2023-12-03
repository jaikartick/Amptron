using System;
using Amptron.Models;
using Amptron.ViewModels.CustomViews;

namespace Amptron.ViewModels.Menu
{
	public partial class DetailViewModel:TabViewModelBase
	{
        public double BatteryLife { get; set; }
        public double BatteryVoltage { get; set; }
        public double Current { get; set; }
        public double CellTemp { get; set; }
        public double BMSTemp { get; set; }

        public bool Cfet_off { get; set; }
        public bool Dfet_off { get; set; }
        public bool Status { get; set; }

        public ObservableCollection<Balancing> Balancings { get; set; } = new ObservableCollection<Balancing>();

        public DetailViewModel()
        {
            BatteryLife = 20;
            Cfet_off = false;
            Dfet_off = true;
            Status = false;
            BatteryVoltage = 12.00;

            Current = 0;
            CellTemp = 41;
            BMSTemp = 41;

            Balancings = new ObservableCollection<Balancing>()
            {
                new Balancing(){ Id = 1, Voltage = 12 },
                new Balancing(){ Id = 2, Voltage = 11 },
                new Balancing(){ Id = 3, Voltage = 12 },
                new Balancing(){ Id = 4, Voltage = 10 },
                new Balancing(){ Id = 5, Voltage = 10 },
                new Balancing(){ Id = 6, Voltage = 12 }
            };
        }

        public override async Task InitializeAsync(Dictionary<string, object> parameters)
        {
            BottomTabViewModel.SetSelectedTabImageAndLabel(1);
            await base.InitializeAsync(parameters);
        }
    }
}

