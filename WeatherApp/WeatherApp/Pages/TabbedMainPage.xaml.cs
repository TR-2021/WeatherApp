
using Xamarin.Forms.Xaml;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedMainPage : Xamarin.Forms.TabbedPage
    {
        private Page PreviousPage { get; set; }
        public TabbedMainPage()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom)
                        .SetIsSwipePagingEnabled(true)
                        .SetIsLegacyColorModeEnabled(true);
            PreviousPage = CurrentPage;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
        }

        private async void TabbedPage_CurrentPageChanged(object sender, System.EventArgs e)
        {
            if(PreviousPage is NavigationPage)
            {
                await PreviousPage.Navigation.PopToRootAsync();
            }
            PreviousPage = CurrentPage;
        }
    }
}