using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using WeatherApp.Interfaces;
using WeatherApp.Pages;
using WeatherApp.Data;
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
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = this;
        }


        private async void WeatherItem_OnTap(object sender, System.EventArgs e)
        {
            WeatherItem item = sender as WeatherItem;
            if (item == null)
                return;
            Weather weather = new Weather();
            weather.Humidity = item.Humidity;
            weather.Time = item.WeatherTime;
            weather.WeatherType = item.WeatherType;
            weather.Temperature = item.Temperature;
            // TODO Get WeatherObject properly

            switch (item.ItemDirection)
            {
                case FlexDirection.Column:
                    await Navigation.PushAsync(new WeatherPage(weather), false);
                    break;
                case FlexDirection.Row:
                    await Navigation.PushModalAsync(new WeatherIteamModalPage(weather), false);
                    break;
            }
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //IToast toast = DependencyService.Get<IToast>();
            //toast.Toast("Appearing " + Title);
        }

        protected override void OnDisappearing()
        {
            IToast toast = DependencyService.Get<IToast>();
            toast.Toast("DisAppearing" + Title);
            base.OnDisappearing();
        }
    }
}
