using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp.Converter
{
    public class ForecastEnumToImageConverter : IValueConverter
    {
        public enum ForecastEnum : uint
        {
            Sunny,
            Cloudy,
            Rain,
            Thunder,
            Unknown
        }
      
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ForecastEnum d = (ForecastEnum)value;
            return (string)GetResource(d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0; // TODO make properly
        }

        public static string GetResource(ForecastEnum weather)
        {
            string resourceName = "unknown.png";

            switch (weather)
            {
                case ForecastEnum.Sunny: resourceName = "sunny.png"; break;
                case ForecastEnum.Cloudy: resourceName = "cloudy.png"; break;
                case ForecastEnum.Rain: resourceName = "rain.png"; break;
                case ForecastEnum.Thunder: resourceName = "thunder.png"; break;
            }
            return resourceName;
        }
    }
}
