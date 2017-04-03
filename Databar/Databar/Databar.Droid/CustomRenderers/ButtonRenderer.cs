
using Xamarin.Forms;
using Databar.CustomElements;
using Xamarin.Forms.Platform.Android;
using Android.Support.V4.Content;

[assembly: ExportRenderer(typeof(BorderButton), typeof(Databar.Droid.CustomRenderers.BorderButtonRenderer))]
namespace Databar.Droid.CustomRenderers
{
    public class BorderButtonRenderer:ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            Control.Background = ContextCompat.GetDrawable(this.Context, Resource.Drawable.button_bg);
        }
    }
}