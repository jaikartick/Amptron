using System;
using Amptron.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;
using UIKit;

namespace Amptron.Platforms.iOS.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                return;
            }

            Control.BorderStyle = UITextBorderStyle.None;
            Control.LeftView = new UIView(new CoreGraphics.CGRect(15, 0, 0, 0));
            if (e.NewElement is BorderlessEntry borderlessEntry)
            {
                this.Control.TintColor = Color.FromRgb(10, 99, 106).ToPlatform();
                Control.Placeholder = borderlessEntry.Placeholder;
                Control.UpdateMaximumWidth(borderlessEntry);
            }
        }
    }
}

