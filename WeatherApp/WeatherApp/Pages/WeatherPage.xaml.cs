using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;
using WeatherApp.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static WeatherApp.MainPage;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public Weather Weather { get; set; } = new Weather();

        public WeatherPage(Weather _weather)
        {
            Weather = _weather;
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }

      
    }
}