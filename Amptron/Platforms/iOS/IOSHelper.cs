using System;
using UIKit;

namespace Amptron.Platforms.iOS
{
	public class IOSHelper
	{
        public static bool IsLowerThanIphoneX()
        {
            if (DeviceInfo.Idiom == DeviceIdiom.Phone)
            {
                var xxx = UIDevice.CurrentDevice.GetType();

                if (UIKit.UIScreen.MainScreen.NativeBounds.Height < 2436)
                {
                    return true;
                }
            }
            return false;

        }
    }
}

