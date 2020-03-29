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
        }

        async Task initializeMap()
        {
            User fakeUser = new User();
            await fakeUser.UpdateLocation();
            Position position = new Position(fakeUser.Latitude, fakeUser.Longitude);
            MapSpan mapSpan = new MapSpan(position, 0.05, 0.05);
            map.MoveToRegion(mapSpan);

            List<User> allUsers = await firebaseHelper.GetAllUsers();
            for (int i = 0; i < allUsers.Count; i++)
            {
                double lat = allUsers[i].Latitude;
                double lon = allUsers[i].Longitude;

                if (lat != 0 && lon != 0)
                {
                    var pin = new Pin()
                    {
                        Position = new Position(lat, lon),
                        Label = allUsers[i].Email
                    };
                    map.Pins.Add(pin);
                }
            }
            map.IsShowingUser = true;
        }

        void ClickMenu(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigPage());
        }
    }
}