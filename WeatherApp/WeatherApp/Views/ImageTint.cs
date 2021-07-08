using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using WeatherApp.Data;

namespace WeatherApp.Views
{
    public class ImageTint : Image
    {
        public readonly static BindableProperty TintColorProperty = BindableProperty.Create("TintColor", typeof(Color), typeof(ImageTint));
        public readonly static BindableProperty TintModeProperty = BindableProperty.Create("TintMode", typeof(Enums.TintModeEnum), typeof(ImageTint));

        public Color TintColor
        { 
            get { return (Color)GetValue(TintColorProperty); }
            set{ SetValue(TintColorProperty, value); }
        }

        public Enums.TintModeEnum TintMode
        {
            get { return (Enums.TintModeEnum)GetValue(TintModeProperty); }
            set { SetValue(TintColorProperty, value); }
        }

    }
}
