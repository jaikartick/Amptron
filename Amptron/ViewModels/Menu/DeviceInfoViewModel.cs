using System;
using Amptron.Models;

namespace Amptron.ViewModels.Menu
{
	public partial class DeviceInfoViewModel : TabViewModelBase
	{
        public BluetoothDevice Device { get; set; }

        public bool IsEditName { get; set; }

        public DeviceInfoViewModel()
        {
            Device = new BluetoothDevice() { DeviceId = Guid.NewGuid(), DeviceModel = "NEX001", DeviceName = "NEX001", NoOfCycles = 100, Version = "965234684133", ProtocolVersion = "242342", Protocol = "Modbus TCP", LastUpdated = DateTime.Now, Status = "Active", SNCode = "123214214" };
        }

        public override async Task InitializeAsync(Dictionary<string, object> parameters)
        {
            BottomTabViewModel.SetSelectedTabImageAndLabel(2);
            await base.InitializeAsync(parameters);
        }

        [RelayCommand]
        private void Edit()
        {
            IsEditName = true;
        }
    }
}

