using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static WeatherApp.MainPage;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherIteamModalPage : ContentPage
    {

        public Weather Weather { get; set; } = new Weather();
        public WeatherIteamModalPage(Weather _weather)
        {

            Weather = _weather;
            InitializeComponent();
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {
                Navigation.PopModalAsync(false);
            };
            backgroundView.GestureRecognizers.Add(tapGesture);

            this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(false);
        }
    }
}