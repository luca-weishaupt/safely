using CustomRenderer;
using Safely.Data;
using Safely.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Safely.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMapPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public MyMapPage()
        {
            InitializeComponent();
            initializeMap();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#003d59");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }

        async Task initializeMap()
        {
            User fakeUser = new User();
            await fakeUser.UpdateLocation();
            Position position = new Position(fakeUser.Latitude, fakeUser.Longitude);
            MapSpan mapSpan = new MapSpan(position, 0.05, 0.05);
            CustomMap customMap = new CustomMap(mapSpan);
            Content = customMap;
          /*  customMap.MoveToRegion(mapSpan);*/

            List<User> allUsers = await firebaseHelper.GetAllUsers();
            for (int i = 0; i < allUsers.Count; i++)
            {
                double lat = allUsers[i].Latitude;
                double lon = allUsers[i].Longitude;

                if (lat != 0 && lon != 0)
                {
                    var pin = new CustomPin()
                    {
                        Position = new Position(lat, lon),
                        Label = allUsers[i].Email,
                        Status = allUsers[i].Status
                    };
                    customMap.Pins.Add(pin);
                }
            }
            customMap.IsShowingUser = true;
        }

        void ClickMenu(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigPage());
        }
    }
}