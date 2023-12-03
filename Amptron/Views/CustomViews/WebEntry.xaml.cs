using System.Windows.Input;

namespace Amptron.Views.CustomViews;

public partial class WebEntry : ContentView
{
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(WebEntry), string.Empty, BindingMode.OneWay);

    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public static readonly BindableProperty FieldNameProperty = BindableProperty.Create(nameof(FieldName), typeof(string), typeof(WebEntry), string.Empty, BindingMode.OneWay);

    public string FieldName
    {
        get => (string)GetValue(FieldNameProperty);
        set => SetValue(FieldNameProperty, value);
    }

    public static readonly BindableProperty FieldNameColorProperty = BindableProperty.Create(nameof(FieldNameColor), typeof(Color), typeof(WebEntry), Color.FromArgb("#26A8E1"), BindingMode.OneWay);

    public Color FieldNameColor
    {
        get => (Color)GetValue(FieldNameColorProperty);
        set => SetValue(FieldNameColorProperty, value);
    }

    public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(WebEntry), 20, BindingMode.OneWay);

    public int MaxLength
    {
        get => (int)GetValue(MaxLengthProperty);
        set => SetValue(MaxLengthProperty, value);
    }

    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(WebEntry), Keyboard.Default, BindingMode.OneWay);

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(WebEntry), false, BindingMode.OneWay, propertyChanged: OnIsPasswordChanged);

    private static void OnIsPasswordChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is WebEntry webEntry)
        {
            if (!webEntry.IsPassword)
            {
                webEntry.HideValue = false;
            }
        }
    }

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public static readonly BindableProperty HideValueProperty = BindableProperty.Create(nameof(HideValue), typeof(bool), typeof(WebEntry), false, BindingMode.TwoWay);

    public bool HideValue
    {
        get => (bool)GetValue(HideValueProperty);
        set => SetValue(HideValueProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(WebEntry), string.Empty, BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(WebEntry), string.Empty, BindingMode.OneWay);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty AddOnFieldValueProperty = BindableProperty.Create(nameof(AddOnFieldValue), typeof(string), typeof(WebEntry), string.Empty, BindingMode.OneWay);

    public string AddOnFieldValue
    {
        get => (string)GetValue(AddOnFieldValueProperty);
        set => SetValue(AddOnFieldValueProperty, value);
    }

    public static readonly BindableProperty TextChangedCommandProperty = BindableProperty.Create(nameof(TextChangedCommand), typeof(ICommand), typeof(WebEntry), null, BindingMode.OneWay);

    public ICommand TextChangedCommand
    {
        get => (ICommand)GetValue(TextChangedCommandProperty);
        set => SetValue(TextChangedCommandProperty, value);
    }

    public WebEntry()
    {
        InitializeComponent();
        this.IsEnabled = true;
    }

    void ShowOrHideValue_Tapped(System.Object sender, System.EventArgs e)
    {
        HideValue = !HideValue;
    }

    void BorderlessEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        this.TextChangedCommand?.Execute(e.NewTextValue);
    }
}
