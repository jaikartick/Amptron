using Amptron.Models;

namespace Amptron.Views.CustomViews;

public partial class DeviceView : ContentView
{
    public string DisplayName { get; set; }

    public static readonly BindableProperty StatusColorProperty = BindableProperty.Create(nameof(StatusColor), typeof(Color), typeof(DeviceView), Colors.Transparent, BindingMode.OneWay);

    public Color StatusColor
    {
        get => (Color)GetValue(StatusColorProperty);
        set => SetValue(StatusColorProperty, value);
    }

    public static readonly BindableProperty DeviceProperty = BindableProperty.Create(nameof(Device), typeof(BluetoothDevice), typeof(DeviceView), null, BindingMode.OneWay, propertyChanged: OnDeviceChanged);

    public BluetoothDevice Device
    {
        get => (BluetoothDevice)GetValue(DeviceProperty);
        set => SetValue(DeviceProperty, value);
    }

    private static void OnDeviceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DeviceView view)
        {
            view.DisplayName = string.IsNullOrWhiteSpace(view.Device.DeviceName) ? view.Device.DeviceCode.ToString() : view.Device.DeviceName;
        }
    }

    public DeviceView()
    {
        InitializeComponent();
    }
}
