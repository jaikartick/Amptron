using System;
using Amptron.Controls;
using Android.Content;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;

namespace Amptron.Platforms.Android.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                return;
            }

            Control.SetBackground(null);
            Control.SetPadding(5, 0, 0, 0);

            if (!(e.NewElement is BorderlessEntry borderlessEntry))
            {
                return;
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(Control is { Text: { } }))
            {
                return;
            }

            if (e.Start != Control.Text.Length || e.End != Control.Text.Length)
            {
                Control.SetSelection(Control.Text.Length, Control.Text.Length);
            }
        }

        protected override FormsEditText CreateNativeControl()
        {
            return new CustomEditText(Context);
        }
    }

    public class CustomEditText : FormsEditText
    {
        public CustomEditText(Context context) : base(context)
        {
        }

        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;


        protected override void OnSelectionChanged(int selStart, int selEnd)
        {
            SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(selStart, selEnd));
            base.OnSelectionChanged(selStart, selEnd);
        }
    }

    public class SelectionChangedEventArgs : EventArgs
    {
        public SelectionChangedEventArgs(int start, int end)
        {
            Start = start;
            End = end;
        }

        public int Start { get; }
        public int End { get; }
    }

    public class MyAutoCompleteEntryRenderer : EntryRenderer
    {
        public MyAutoCompleteEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                return;
            }

            Control.SetBackground(null);
            Control.SetPadding(5, 0, 0, 0);

            if (!(e.NewElement is BorderlessEntry borderlessEntry))
            {
                return;
            }
        }
    }
}

