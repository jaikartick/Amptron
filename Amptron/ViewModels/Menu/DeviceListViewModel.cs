using Microsoft.Maui.Controls;
using System;
using Amptron.Helpers;
using Amptron.Models;
using Amptron.Views.Menu;
using System.Windows.Input;

namespace Amptron.ViewModels.Menu
{
	public partial class DeviceListViewModel:TabViewModelBase
	{
        public ObservableCollection<BluetoothDevice> Devices { get; set; } = new ObservableCollection<BluetoothDevice>();

        public bool IsDevicesEmpty { get; set; } = true;

        public override async Task InitializeAsync(Dictionary<string, object> parameters)
        {
            BottomTabViewModel.SetSelectedTabImageAndLabel(4);
            await base.InitializeAsync(parameters);
            if (parameters.TryGetValue(NavigationKeys.AddedDevices, out var devices) && devices is IEnumerable<BluetoothDevice> bluetoothDevices)
            {
                var devicesList = Devices.ToList();
                devicesList.AddRange(bluetoothDevices);
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var device in bluetoothDevices)
                    {
                        Devices = new ObservableCollection<BluetoothDevice>(devicesList);
                    }
                    IsDevicesEmpty = Devices.Count == 0;
                });
            }
        }

        [RelayCommand]
        public async Task AddDeviceAsync()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(NavigationKeys.ExistingDevices, Devices.Select(d => d.DeviceId));
            await NavigationService.NavigateToAsync<AddDeviceViewModel>(typeof(AddDevicePage), parameters);
        }

    }
}

