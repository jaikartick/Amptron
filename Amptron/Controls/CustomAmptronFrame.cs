using System;
namespace Amptron.Controls
{
    public class CustomAmptronFrame : Frame
    {
        public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(CornerRadius), typeof(CustomAmptronFrame));

        public CustomAmptronFrame()
        {
            base.CornerRadius = 0;
        }

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}

