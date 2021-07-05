using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherIcon : ContentView, INotifyPropertyChanged
    {
        public static readonly BindableProperty WeatherTypeProperty = BindableProperty.Create("WeatherType", typeof(string), typeof(WeatherIcon),propertyChanged:
        (BindableObject bindable, object oldValue, object newValue) =>{
            (bindable as WeatherIcon).weatherIcon.SetValue(Image.SourceProperty, newValue);
        });
        
        public string WeatherType
        {
            get { 
                return (string)GetValue(WeatherTypeProperty); 
            }
            set { 
                SetValue(WeatherTypeProperty, value); 
            }
        }
        
        public WeatherIcon()
        {
            InitializeComponent();
        }
    }
}