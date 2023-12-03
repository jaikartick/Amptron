using System;
using Amptron.Views.Onboarding;

namespace Amptron.Controls
{
    public class CarouselTemplateSelector : DataTemplateSelector
    {
        private DataTemplate view1 = new DataTemplate(typeof(Onboarding_View1));
        private DataTemplate view2 = new DataTemplate(typeof(Onboarding_View2));
        private DataTemplate view3 = new DataTemplate(typeof(Onboarding_View3));

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var dataTemplate = view1;
            if (item is int viewNumber)
            {
                switch (viewNumber)
                {
                    case 1:
                        dataTemplate = view1;
                        break;
                    case 2:
                        dataTemplate = view2;
                        break;
                    case 3:
                        dataTemplate = view3;
                        break;
                }
            }
            return dataTemplate;
        }
    }
}

