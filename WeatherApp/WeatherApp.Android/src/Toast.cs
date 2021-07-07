using Android.Widget;
using WeatherApp.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(WeatherApp.Droid.src.Toast))]
namespace WeatherApp.Droid.src
{
    class Toast : IToast
    {
        void IToast.Toast(string Message)
        {
            MainThread.InvokeOnMainThreadAsync(() => {
                Android.Widget.Toast.MakeText(Android.App.Application.Context, Message, ToastLength.Long).Show();
            });
        }
    }
}