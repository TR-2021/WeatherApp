using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Text { get; set; } = "NO TEXT";
        public string this[string text] => GetTranslatedText(text);

        private CultureInfo _curentCulture = CultureInfo.CurrentUICulture;

        public TestPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        public TestPage(string text)
        {
            Text = text;
            InitializeComponent();
            this.BindingContext = this;
            GetTranslatedText("infoText");

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TestPage(Text + "." + new Random().Next(0, 5)));
        }
        private string GetTranslatedText(string key)
        {
            ResourceManager manager = new ResourceManager(typeof(WeatherResource));
            string text = "";
            try
            {
                text = manager.GetString(key,_curentCulture);
            }
            catch (Exception e)
            {
                var exceprion = e.Message;
            }
            if (text == null)
            {
                text = "";
            }
            return text;
        }
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Text = new Random().Next(1, 10).ToString();
          
        }

        private void EnglishButtonClicked(object sender, EventArgs e)
        {
            SetCultureInfo(new CultureInfo("en"));
        }
        private void RussianButtonClicked(object sender, EventArgs e)
        {
            SetCultureInfo(new CultureInfo("ru"));
        }

        public void SetCultureInfo(CultureInfo cultureInfo)
        {
            _curentCulture = cultureInfo;
            PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
    }
}