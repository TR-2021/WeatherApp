using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static WeatherApp.Converter.ForecastEnumToImageConverter;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherItem : ContentView
    {
        public static readonly BindableProperty WeatherTimeProperty = BindableProperty.Create("WeatherTime", typeof(string), typeof(WeatherItem), "", propertyChanged: WeatherTimerPropertyChanged);
        public static readonly BindableProperty WeatherTypeProperty = BindableProperty.Create("WeatherType", typeof(ForecastEnum), typeof(WeatherItem), ForecastEnum.Thunder, propertyChanged: WeatherTypePropertyChanged);
        public static readonly BindableProperty TemperatureProperty = BindableProperty.Create("Temperature", typeof(string), typeof(WeatherItem), "", propertyChanged: TemperaturePropertyChanged);
        public static readonly BindableProperty ItemDirectionProperty = BindableProperty.Create("ItemDirection", typeof(FlexDirection), typeof(WeatherItem), FlexDirection.Column, propertyChanged: ItemDirectionPropertyChanged);

      
        public string WeatherTime { get { return (string)GetValue(WeatherTimeProperty);} set { SetValue(WeatherTimeProperty, value); } }
        public ForecastEnum WeatherType { get { return (ForecastEnum)GetValue(WeatherTypeProperty); } set { SetValue(WeatherTypeProperty, value); } }
        public string Temperature { get { return (string)GetValue(TemperatureProperty); } set { SetValue(TemperatureProperty, value); } }
        public FlexDirection ItemDirection { get { return (FlexDirection)GetValue(ItemDirectionProperty); } set { SetValue(ItemDirectionProperty, value); } }

        public WeatherItem()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private static void WeatherTimerPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as WeatherItem).timeLabel.Text = (string)newValue;
        }
        private static void WeatherTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as WeatherItem).weatherIcon.SetValue(WeatherIcon.WeatherTypeProperty, newValue);
        }
        private static void TemperaturePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as WeatherItem).temperatureLabel.Text = (string)newValue;
        }
        private static void ItemDirectionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as WeatherItem).flexLayout.Direction = (FlexDirection)newValue;
        }

    }
}