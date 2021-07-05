using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Converter;
using WeatherApp.Views;
using Xamarin.Forms;
using static WeatherApp.Converter.ForecastEnumToImageConverter;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public static readonly BindableProperty CurrentWeatherProperty = BindableProperty.Create("CurrentWeather", typeof(ForecastEnum), typeof(MainPage), ForecastEnum.Thunder);
        public ForecastEnum CurrentWeather
        {
            get { return (ForecastEnum)GetValue(CurrentWeatherProperty); }
            set { SetValue(CurrentWeatherProperty, value); }
        }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
