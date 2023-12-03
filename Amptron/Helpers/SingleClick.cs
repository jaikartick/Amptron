using System;
namespace Amptron.Helpers
{
    public class SingleClick
    {
        bool hasClicked;
        int customDelay = 0;
        #region Button Click  
        Action _setClick;
        public SingleClick(Action setClick)
        {
            _setClick = setClick;
        }
        public SingleClick(Action setClick, int customDelay)
        {
            _setClick = setClick;
            this.customDelay = customDelay;
        }
        #endregion Button Click  

        public Action Click()
        {
            return () =>
            {
                if (!hasClicked)
                {
                    _setClick.Invoke();
                    hasClicked = true;
                }
                Reset();
            };
        }
        async void Reset()
        {
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                await Task.Delay(800);
            }
            else
            {
                if (customDelay == 0)
                {
                    await Task.Delay(900);
                }
                else
                {
                    await Task.Delay(customDelay);
                }
            }
            await Task.Run(new Action(() => hasClicked = false));
        }
    }

    public class SingleClick<T>
    {
        bool hasClicked;
        int customDelay = 0;
        #region Button Click  
        Action<T> _setClick;
        public SingleClick(Action<T> setClick)
        {
            _setClick = setClick;
        }
        #endregion Button Click  

        public Action<T> Click()
        {
            return (obj) =>
            {
                if (!hasClicked)
                {
                    _setClick.Invoke(obj);
                    hasClicked = true;
                }
                Reset();
            };
        }
        async void Reset()
        {
            if (customDelay == 0)
            {
                await Task.Delay(800);
            }
            else
            {
                await Task.Delay(customDelay);
            }
            await Task.Run(new Action(() => hasClicked = false));
        }
    }
}

