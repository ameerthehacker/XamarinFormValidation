using Xamarin.Forms;
using XamarinFormValidation.Validators.Contracts;
using XamarinFormValidation.Effects;

namespace XamarinFormValidation.Validators.Implementations
{
    public class BasicErrorStyle: IErrorStyle
    {
        public void ShowError(View view, string message)
        {
            BorderEffect.SetBorderColor(view, Color.Red);
            BorderEffect.SetHasBorderEffect(view, true);
        }

        public void RemoveError(View view)
        {
            BorderEffect.SetHasBorderEffect(view, false);
        }
    }
}
