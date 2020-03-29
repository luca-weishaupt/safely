using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safely.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Safely.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigPage : ContentPage
    {
        public NavigPage()
        {
            InitializeComponent();
        }

        void RedirectClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Text.Equals("Map"))
            {
                Navigation.PushAsync(new MyMapPage());
            }
            else if (b.Text.Equals("Update my status"))
            {
                Navigation.PushAsync(new StatusPage());
            }

            else if (b.Text.Equals("About"))
            {
                BrowserT browser = new BrowserT();
                browser.OpenBrowser(new Uri("https://github.com/luca-weishaupt/safely"));
            }

            else if (b.Text.Equals("Log out"))
            {
                Navigation.PushAsync(new LoginPage());
                
            }
        }

        public class BrowserT
        {
            public async Task OpenBrowser(Uri uri)
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
        }



    }
}