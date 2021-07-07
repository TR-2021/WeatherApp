using static WeatherApp.Converter.ForecastEnumToImageConverter;

namespace WeatherApp.Data
{
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
