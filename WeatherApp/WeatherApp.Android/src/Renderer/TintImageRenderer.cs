using Android.Content;
using Android.Util;
using Android.Widget;
using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WeatherApp.Views;
using WeatherApp.Droid.Src.Renderer;
using System.ComponentModel;
using Android.Graphics;

[assembly: ExportRenderer(typeof(ImageTint), typeof(TintImageRenderer))]
namespace WeatherApp.Droid.Src.Renderer
{
    public class TintImageRenderer : ImageRenderer
    {
        private PorterDuff.Mode _mode = PorterDuff.Mode.Add;
        ImageTint image = null;

        public TintImageRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Image> args)
        {
            base.OnElementChanged(args);
            image = Element as ImageTint;

            setTintMode();
            changeColor();
        }

     
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == ImageTint.TintColorProperty.PropertyName )
            {
                 changeColor();
            }
            if (e.PropertyName == ImageTint.TintModeProperty.PropertyName)
            {
                setTintMode();
                changeColor();
            }
        }

        private void changeColor()
        {
            if (image.IsSet(ImageTint.TintColorProperty))
            {
                Android.Graphics.Color color = Android.Graphics.Color.ParseColor(image.TintColor.ToHex());
                Control.SetColorFilter(color, _mode);
            }
        }
        private void setTintMode()
        {
            if (image.IsSet(ImageTint.TintModeProperty))
            {
                _mode = PorterDuff.Mode.ValueOf(image.TintMode.ToString());
            }
        }

    }
}