using System;
using Amptron.Helpers;
using Amptron.Models;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;

namespace Amptron.ViewModels.Menu
{
	public partial class AddDeviceViewModel : ViewModelBase
	{
        private readonly IAdapter _bluetoothAdapter;

        public ObservableCollection<BluetoothDevice> Devices { get; set; } = new ObservableCollection<BluetoothDevice>();

        public bool IsDevicesEmpty => Devices.Count == 0;

        private List<IDevice> _allDevices = new List<IDevice>();
        private IEnumerable<Guid> _existingDevices = new List<Guid>();

        public string SearchText { get; set; }

        public AddDeviceViewModel()
        {
            _bluetoothAdapter = CrossBluetoothLE.Current.Adapter;
            _bluetoothAdapter.DeviceDiscovered += _bluetoothAdapter_DeviceDiscovered;
        }

        [RelayCommand]
        private void FilterDevice(string obj)
        {
            Devices = new ObservableCollection<BluetoothDevice>(_allDevices.Where(d => (d.Name != null && d.Name.Contains(obj)) || d.NativeDevice.ToString().Contains(obj)).Select(bd => new BluetoothDevice(bd)));
        }

        [RelayCommand]
        private async void SelectDevice(BluetoothDevice device)
        {
            var selectedDevice = Devices.IndexOf(device);
            device.IsSelected = !device.IsSelected;
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Devices[selectedDevice] = device;
            });
        }

        [RelayCommand]
        private async void Add()
        {
            var devices = Devices.Where(d => d.IsSelected);
            var parameters = new Dictionary<string, object>();
            parameters.Add(NavigationKeys.AddedDevices, devices);
            await NavigationService.GoBackAsync(parameters);
        }

        [RelayCommand]
        public async Task ScanDeviceAsync()
        {
            IsBusy = true;

            if (!await PermissionsGrantedAsync())
            {
                await Application.Current.MainPage.DisplayAlert("Permission required", "Application needs location permission", "OK");
                IsBusy = false;
                return;
            }

            _allDevices.Clear();
            if (!_bluetoothAdapter.IsScanning)
            {
                await _bluetoothAdapter.StartScanningForDevicesAsync();
            }
            var discoveredDevices = _bluetoothAdapter.DiscoveredDevices;
            foreach (var device in discoveredDevices)
            { 
                if (!_allDevices.Any(d => d.Id.Equals(device.Id)))
                {
                    _allDevices.Add(device);
                    if (!Devices.Any(d => d.DeviceId.Equals(device.Id)) && !_existingDevices.Any(d => d.Equals(device.Id)))
                    {
                        if (!string.IsNullOrWhiteSpace(SearchText))
                        {
                            if (device.Name != null && device.Name.Contains(SearchText) || device.NativeDevice.ToString().Contains(SearchText))
                            {
                                Devices.Add(new BluetoothDevice(device));
                            }
                        }
                        else
                        {
                            Devices.Add(new BluetoothDevice(device));
                        }
                    }
                }
            }

            IReadOnlyList<IDevice> pairedDevices = null;
            pairedDevices = _bluetoothAdapter.GetSystemConnectedOrPairedDevices(Array.Empty<Guid>());

            foreach (var device in pairedDevices)
            {
                if (!_allDevices.Any(d => d.Id.Equals(device.Id)))
                {
                    _allDevices.Add(device);
                    if (!Devices.Any(d => d.DeviceId.Equals(device.Id)) && !_existingDevices.Any(d => d.Equals(device.Id)))
                    {
                        if (!string.IsNullOrWhiteSpace(SearchText))
                        {
                            if (device.Name != null && device.Name.Contains(SearchText) || device.NativeDevice.ToString().Contains(SearchText))
                            {
                                Devices.Add(new BluetoothDevice(device));
                            }
                        }
                        else
                        {
                            Devices.Add(new BluetoothDevice(device));
                        }
                    }
                }
            }

            IsBusy = false;
        }

        private async Task<bool> PermissionsGrantedAsync()
        {
            var locationPermissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();

            if (locationPermissionStatus != PermissionStatus.Granted)
            {
                if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
                {
                    // Prompt the user with additional information as to why the permission is needed
                }
                var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                return status == PermissionStatus.Granted;
            }
            return true;
        }

        public override async Task InitializeAsync(Dictionary<string, object> parameters)
        {
            await base.InitializeAsync(parameters);
            if (parameters.TryGetValue(NavigationKeys.ExistingDevices, out object deviceIds) && deviceIds is IEnumerable<Guid> ids)
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    _existingDevices = ids;
                });
            }
            if (!_bluetoothAdapter.IsScanning)
            {
                await ScanDeviceAsync();
            }
        }

        private async void _bluetoothAdapter_DeviceDiscovered(object sender, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs e)
        {
            if (!e.Device.IsConnectable)
            {
                return;
            }
            if (e.Device != null && !_allDevices.Any(d => d.Id.Equals(e.Device.Id)))
            {
                _allDevices.Add(e.Device);
                if (!Devices.Any(d => d.DeviceId.Equals(e.Device.Id)) && !_existingDevices.Any(d => d.Equals(e.Device.Id)))
                {
                    if (!string.IsNullOrWhiteSpace(SearchText))
                    {
                        if (e.Device.Name != null && e.Device.Name.Contains(SearchText) || e.Device.NativeDevice.ToString().Contains(SearchText))
                        {
                            Devices.Add(new BluetoothDevice(e.Device));
                        }
                    }
                    else
                    {
                        Devices.Add(new BluetoothDevice(e.Device));
                    }
                }
            }
        }
    }
}

