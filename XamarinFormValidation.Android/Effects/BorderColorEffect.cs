using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinFormValidation.Android.Effects;

[assembly: ResolutionGroupName("XamarinFormValidation")]
[assembly: ExportEffect(typeof(BorderColorEffect), "BorderColorEffect")]
namespace XamarinFormValidation.Android.Effects
{
    public class BorderColorEffect : PlatformEffect
    {
        public Drawable oldBackground;

        protected override void OnAttached()
        {
            if (Control != null)
            {
                try
                {
                    oldBackground = Control.Background;
                    Control.Background.SetColorFilter(
                        XamarinFormValidation.Effects.BorderEffect.GetBorderColor(Element).ToAndroid(), 
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
                Control.Background = oldBackground;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
