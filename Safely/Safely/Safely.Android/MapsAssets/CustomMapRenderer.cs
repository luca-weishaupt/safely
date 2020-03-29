using Android.Content;
using Android.Gms.Maps.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Safely.Data;
using Safely.Model;
using MapsAssets.Droid;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MapsAssets.Droid
{
    public class CustomMapRenderer : MapRenderer
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        //CustomCircle circle;

        public CustomMapRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                //circle = formsMap.Circle;
            }
        }

        protected async override void OnMapReady(Android.Gms.Maps.GoogleMap map)
        {
            base.OnMapReady(map);

            List<User> allUsers = await firebaseHelper.GetAllUsers();
            for (int i = 0; i < allUsers.Count; i++)
            {
                double lat = allUsers[i].Latitude;
                double lon = allUsers[i].Longitude;

                if (lat != 0 && lon != 0)
                {
                    var circleOptions = new CircleOptions();
                    circleOptions.InvokeCenter(new LatLng(lat, lon));
                    circleOptions.InvokeRadius(1000);
                    circleOptions.InvokeFillColor(0X66FF0000);
                    circleOptions.InvokeStrokeColor(0X66FF0000);
                    circleOptions.InvokeStrokeWidth(0);

                    NativeMap.AddCircle(circleOptions);
                }
            }

            
        }
    }
}
