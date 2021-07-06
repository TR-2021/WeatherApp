using System.Collections.ObjectModel;
using WeatherApp.Views;
using Xamarin.Forms;
using static WeatherApp.Converter.ForecastEnumToImageConverter;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        //public static readonly BindableProperty CurrentWeatherProperty = BindableProperty.Create("CurrentWeather", typeof(ForecastEnum), typeof(MainPage), ForecastEnum.Thunder);
        public ObservableCollection<Weather> WeatherStateList { get; set; } = new ObservableCollection<Weather>();
        public Weather CurrentWeather { get; set; } = new Weather();
        public MainPage()
        {
            PupulateList();
            InitializeComponent();
            BindingContext = this;
        }

        private void PupulateList()
        {
            WeatherStateList.Add(new Weather() { Temperature = "52", Time = "Now", Humidity = "10", Day = "Monday", WeatherType = ForecastEnum.Cloudy });
            WeatherStateList.Add(new Weather() { Temperature = "12", Time = "1AM", Humidity = "20", Day = "Tuesday", WeatherType = ForecastEnum.Sunny });
            WeatherStateList.Add(new Weather() { Temperature = "22", Time = "2AM", Humidity = "30", Day = "Wednesday", WeatherType = ForecastEnum.Thunder });
            WeatherStateList.Add(new Weather() { Temperature = "42", Time = "3AM", Humidity = "30", Day = "Thursday", WeatherType = ForecastEnum.Rain });
            WeatherStateList.Add(new Weather() { Temperature = "52", Time = "4AM", Humidity = "40", Day = "Friday", WeatherType = ForecastEnum.Sunny });
            WeatherStateList.Add(new Weather() { Temperature = "62", Time = "5AM", Humidity = "50", Day = "Saturday", WeatherType = ForecastEnum.Sunny });
            WeatherStateList.Add(new Weather() { Temperature = "72", Time = "6AM", Humidity = "50", Day = "Sunday", WeatherType = ForecastEnum.Sunny });
            WeatherStateList.Add(new Weather() { Temperature = "32", Time = "7AM", Humidity = "50", Day = "Monday", WeatherType = ForecastEnum.Sunny });
            WeatherStateList.Add(new Weather() { Temperature = "52", Time = "8AM", Humidity = "50", Day = "Tuesday", WeatherType = ForecastEnum.Sunny });
            WeatherStateList.Add(new Weather() { Temperature = "72", Time = "9AM", Humidity = "50", Day = "Wednesday", WeatherType = ForecastEnum.Sunny });
            WeatherStateList.Add(new Weather() { Temperature = "32", Time = "10AM", Humidity = "50", Day = "Thursday", WeatherType = ForecastEnum.Sunny });
            CurrentWeather = WeatherStateList[0];
        }

        public class Weather
        {
            public string Time { get; set; } = "NOW";
            public string Location { get; set; } = "Cupertino";
            public ForecastEnum WeatherType { get; set; } = ForecastEnum.Sunny;
            public string Temperature { get; set; } = "123";
            public string Day { get; set; } = "Monday";
            public string Humidity { get; set; } = "55";

        }
    }
}
