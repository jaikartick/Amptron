using Amptron.Models;

namespace Amptron.Views.CustomViews;

public partial class DeviceItemView : ContentView
{
    public string DisplayName { get; set; }

    public string DeviceCode { get; set; }

    public static readonly BindableProperty DeviceProperty = BindableProperty.Create(nameof(Device), typeof(BluetoothDevice), typeof(DeviceItemView), null, BindingMode.OneWay, propertyChanged: OnDeviceChanged);

    public BluetoothDevice Device
    {
        get => (BluetoothDevice)GetValue(DeviceProperty);
        set => SetValue(DeviceProperty, value);
    }

    private static void OnDeviceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DeviceItemView view)
        {
            view.DisplayName = string.IsNullOrWhiteSpace(view.Device.DeviceName) ? view.Device.DeviceCode.ToString() : view.Device.DeviceName;
            view.DeviceCode = view.Device.DeviceCode.ToString();
        }
    }

    public DeviceItemView()
    {
        InitializeComponent();
    }

    void Edit_Tapped(System.Object sender, System.EventArgs e)
    {
        Device.IsEditName = true;
    }

    void Entry_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        Device.IsEditName = true;
    }
}
