using Android.Graphics.Drawables;
using Xamarin.Forms;

namespace XamarinFormValidation.Effects
{
    public static class BorderEffect {
        public static readonly BindableProperty HasBorderEffectProperty = BindableProperty.Create(
            "HasBorderEffect",
            typeof(bool),
            typeof(BorderEffect),
            propertyChanged: OnHasBorderEffectChanged
        );

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            "BorderColor",
            typeof(Color),
            typeof(BorderEffect)
        );

        public static bool GetHasBorderEffect(BindableObject view) {
            return (bool)view.GetValue(HasBorderEffectProperty);
        }

        public static void SetHasBorderEffect(BindableObject view, bool value)
        {
            view.SetValue(HasBorderEffectProperty, value);
        }

        public static Color GetBorderColor(BindableObject view)
        {
            return (Color)view.GetValue(BorderColorProperty);
        }

        public static void SetBorderColor(BindableObject view, Color value)
        {
            view.SetValue(BorderColorProperty, value);
        }

        public static void OnHasBorderEffectChanged(BindableObject bindable, object oldValue, object newValue) {
            View view = bindable as View;
            if((bool)newValue) {
                (view as View).Effects.Add(new ViewBorderColorEffect());
            }
            else {
                foreach(Effect effect in view.Effects) {
                    if(effect is ViewBorderColorEffect) {
                        view.Effects.Remove(effect);
                    }
                }
            }
        }
        
        class ViewBorderColorEffect : RoutingEffect
        {
            public ViewBorderColorEffect() : base("XamarinFormValidation.BorderColorEffect") {}
        }
    }

}
