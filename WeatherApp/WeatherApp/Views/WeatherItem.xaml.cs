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
        public event EventHandler OnTap;

        public static readonly BindableProperty WeatherTimeProperty = BindableProperty.Create("WeatherTime", typeof(string), typeof(WeatherItem), "", propertyChanged: WeatherTimerPropertyChanged);
        public static readonly BindableProperty WeatherTypeProperty = BindableProperty.Create("WeatherType", typeof(ForecastEnum), typeof(WeatherItem), ForecastEnum.Thunder, propertyChanged: WeatherTypePropertyChanged);
        public static readonly BindableProperty TemperatureProperty = BindableProperty.Create("Temperature", typeof(string), typeof(WeatherItem), "", propertyChanged: TemperaturePropertyChanged);
        public static readonly BindableProperty HumidityProperty = BindableProperty.Create("Humidity", typeof(string), typeof(WeatherItem), "", propertyChanged: HumidityPropertyChanged);
        public static readonly BindableProperty ItemDirectionProperty = BindableProperty.Create("ItemDirection", typeof(FlexDirection), typeof(WeatherItem), FlexDirection.Row, propertyChanged: ItemDirectionPropertyChanged);
        public static readonly BindableProperty HumidityVisibleProperty = BindableProperty.Create("HumidityVisible", typeof(bool), typeof(WeatherItem), true, propertyChanged: HumidityVisiblePropertyChanged);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(WeatherItem), Color.AliceBlue, propertyChanged: TextColorPropertyChanged);

        public string WeatherTime 
        {
            get { return (string)GetValue(WeatherTimeProperty); } 
            set { SetValue(WeatherTimeProperty, value); } 
        }
        public ForecastEnum WeatherType 
        { 
            get { return (ForecastEnum)GetValue(WeatherTypeProperty); } 
            set { SetValue(WeatherTypeProperty, value); } 
        }
        public string Temperature
        {
            get { return (string)GetValue(TemperatureProperty); }
            set { SetValue(TemperatureProperty, value); }
        }
        public string Humidity
        {
            get { return (string)GetValue(HumidityProperty); }
            set { SetValue(HumidityProperty, value); }
        }
        public bool HumidityVisible
        {
            get { return (bool)GetValue(HumidityVisibleProperty); }
            set { SetValue(HumidityVisibleProperty, value); }
        }
        public FlexDirection ItemDirection 
        { 
            get { return (FlexDirection)GetValue(ItemDirectionProperty); } 
            set { SetValue(ItemDirectionProperty, value); } 
        }
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        public WeatherItem()
        {
            InitializeComponent();
         
            //BindingContext = this;
        }

        private void OnTapped()
        {
            if (OnTap != null)
                OnTap(this, new EventArgs());

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
        private static void HumidityPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as WeatherItem).humidityLabel.Text= (string) newValue;
        }
        private static void HumidityVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as WeatherItem).humidityLabel.SetValue(Label.IsVisibleProperty,newValue);
        }

        private static void TextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as WeatherItem).humidityLabel.SetValue(Label.TextColorProperty, newValue);
            (bindable as WeatherItem).temperatureLabel.SetValue(Label.TextColorProperty, newValue);
            (bindable as WeatherItem).timeLabel.SetValue(Label.TextColorProperty, newValue);
        }

    }
}