using System;
using System.Windows.Input;
using Amptron.Helpers;
using Plugin.BLE.Abstractions.Contracts;
using PropertyChanged;

namespace Amptron.Models
{
    [AddINotifyPropertyChangedInterface]
    public class BluetoothDevice
    {
        public string DeviceModel { get; set; }
        public Guid DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceCode { get; set; }
        public bool IsSelected { get; set; }
        public int NoOfCycles { get; set; }

        public string Version { get; set; }

        public string SNCode { get; set; }

        public string Protocol { get; set; }

        public string ProtocolVersion { get; set; }

        public string Status { get; set; }

        public DateTime LastUpdated { get; set; }

        public bool IsEditName { get; set; }

        public Color StatusColor => Status == "Active" ? Color.FromArgb("#58B05C") : Status == "InActive" ? Color.FromArgb("#EA4643") : Color.FromArgb("#FC950C");

        private ICommand _editCommand;
        public ICommand EditCommand => _editCommand ?? (_editCommand = new Command(new SingleClick(SwitchEditModeTrue()).Click()));

        private ICommand _unfocusedCommand;
        public ICommand UnfocusedCommand => _unfocusedCommand ?? (_unfocusedCommand = new Command(new SingleClick(SwitchEditModeFalse()).Click()));

        private Action SwitchEditModeTrue()
        {
            return async () =>
            {
                IsEditName = true;
            };
        }

        private Action SwitchEditModeFalse()
        {
            return async () =>
            {
                IsEditName = false;
            };
        }

        public BluetoothDevice()
        {

        }

        public BluetoothDevice(IDevice device)
        {
            DeviceId = device.Id;
            DeviceCode = device.NativeDevice.ToString();
            DeviceName = string.IsNullOrWhiteSpace(device.Name) ? device.NativeDevice.ToString() : device.Name;
            DeviceModel = string.IsNullOrWhiteSpace(device.Name) ? device.NativeDevice.ToString() : device.Name;
            Status = "Active";
        }
    }
}

