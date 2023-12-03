namespace Amptron.Views.CustomViews;

public partial class AlarmView : ContentView
{
    public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(AlarmView), string.Empty, BindingMode.OneWay);

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public static readonly BindableProperty AlarmColorProperty = BindableProperty.Create(nameof(AlarmColor), typeof(Color), typeof(AlarmView), Colors.Transparent, BindingMode.OneWay);

    public Color AlarmColor
    {
        get => (Color)GetValue(AlarmColorProperty);
        set => SetValue(AlarmColorProperty, value);
    }

    public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(AlarmView), false, BindingMode.OneWay);

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public AlarmView()
	{
		InitializeComponent();
	}
}
