using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Safely.Views;

namespace Safely
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("stayLoggedIn") && (bool)Application.Current.Properties["stayLoggedIn"] && !((string)Application.Current.Properties["email"]).Equals(""))
            {
                MainPage = new NavigationPage(new StatusPage());
            } else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
