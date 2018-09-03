using System;
using global::Android.Graphics;
using Xamarin.Forms;
using XamarinFormValidation.Effects;
using Xamarin.Forms.Platform.Android;
using XamarinFormValidation.Android.Effects;

[assembly: ResolutionGroupName("XamarinFormValidation")]
[assembly: ExportEffect(typeof(BorderColorEffect), "BorderColorEffect")]
namespace XamarinFormValidation.Android.Effects
{
    public class BorderColorEffect : PlatformEffect
    {
        public ColorFilter oldBackgroundColor;

        protected override void OnAttached()
        {
            if (Control != null)
            {
                try
                {
                    oldBackgroundColor = Control.Background.ColorFilter;
                    Control.Background.SetColorFilter(
                        BorderEffect.GetBorderColor(Element).ToAndroid(), 
                        PorterDuff.Mode.SrcIn
                    );
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        protected override void OnDetached()
        {
            try
            {
                Control.Background.SetColorFilter(oldBackgroundColor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
