using System;
using Amptron.Services.Interfaces;
using Amptron.Views;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using UIKit;

namespace Amptron.Platforms.iOS.Services
{
    public class LoadingPageService : ILoadingPageService
    {
        private UIView _nativeView;

        private bool _isInitialized;

        public void InitLoadingPage(ContentPage loadingIndicatorPage)
        {
            // check if the page parameter is available
            if (loadingIndicatorPage != null && Application.Current.MainPage != null)
            {
                // build the loading page with native base
                loadingIndicatorPage.Parent = Application.Current.MainPage;

                loadingIndicatorPage.Layout(new Rect(0, 0, 300, 600));

                var renderer = loadingIndicatorPage.CreateViewController().View as UIView;

                _nativeView = renderer;

                _isInitialized = true;
            }
        }

        public void ShowLoadingPage()
        {
            // check if the user has set the page or not
            if (!_isInitialized)
                InitLoadingPage(new LoadingIndicatorPage()); // set the default page

            // showing the native loading page
            //MauiUIApplicationDelegate.Current.Application.Windows[0].AddOverlay(_nativeView.InputView);
            var scene = UIApplication.SharedApplication.ConnectedScenes.OfType<UIWindowScene>().SelectMany(s => s.Windows).FirstOrDefault(w => w.IsKeyWindow);
            if (scene != null)
            {
                scene.AddSubview(_nativeView);
            }
        }

        private void XamFormsPage_Appearing(object sender, EventArgs e)
        {
            var animation = new Animation(callback: d => ((ContentPage)sender).Content.Rotation = d,
                start: ((ContentPage)sender).Content.Rotation,
                end: ((ContentPage)sender).Content.Rotation + 360,
                easing: Easing.Linear);
            animation.Commit(((ContentPage)sender).Content, "RotationLoopAnimation", 16, 800, null, null, () => true);
        }

        public void HideLoadingPage()
        {
            // Hide the page
            _nativeView?.RemoveFromSuperview();
        }
    }

    internal static class PlatformExtension
    {
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable)
        {
            var renderer = Microsoft.Maui.Controls.Compatibility.Platform.iOS.Platform.GetRenderer(bindable);
            if (renderer == null)
            {
                renderer = Microsoft.Maui.Controls.Compatibility.Platform.iOS.Platform.CreateRenderer(bindable);
                Microsoft.Maui.Controls.Compatibility.Platform.iOS.Platform.SetRenderer(bindable, renderer);
            }
            return renderer;
        }
    }
}

