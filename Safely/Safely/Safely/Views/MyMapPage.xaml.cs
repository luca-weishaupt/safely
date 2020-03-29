﻿using Safely.Model;
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
        }
    }
}