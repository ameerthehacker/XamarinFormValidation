using Xamarin.Forms;

namespace XamarinFormValidation.Effects
{
    public static class BorderEffect {
        public static readonly BindableProperty HasBorderEffectProperty = BindableProperty.CreateAttached(
            "HasBorderEffect",
            typeof(bool),
            typeof(BorderEffect),
            false,
            propertyChanged: OnHasBorderEffectChanged
        );

        public static readonly BindableProperty BorderColorProperty = BindableProperty.CreateAttached(
            "BorderColor",
            typeof(Color),
            typeof(BorderEffect),
            Color.Default
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
                view.Effects.Add(new ViewBorderColorEffect());
            }
            else {
                for (int i = 0; i < view.Effects.Count; i++) {
                    if(view.Effects[i] is ViewBorderColorEffect) {
                        view.Effects.RemoveAt(i);
                        break;
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
