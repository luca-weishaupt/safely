using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using CustomRenderer;
using CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using static Safely.Model.User;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace CustomRenderer.Droid
{
    public class CustomMapRenderer : MapRenderer
    {
        List<CustomPin> customPins;

        public CustomMapRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            CustomPin customPin = (CustomPin)pin;

            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetAlpha(0);

            var circleOptions = new CircleOptions();
            circleOptions.InvokeCenter(new LatLng(customPin.Position.Latitude, customPin.Position.Longitude));
            circleOptions.InvokeRadius(1000);
            circleOptions.InvokeStrokeWidth(0);

            switch (customPin.Status)
            {
                case StatusEnum.Diagnosed:
                    circleOptions.InvokeFillColor(0X66FF0000);
                    circleOptions.InvokeStrokeColor(0X66FF0000);
                    NativeMap.AddCircle(circleOptions);
                    break;
                case StatusEnum.Healthy:
                    break;
                case StatusEnum.Recovered:
                    break;
                case StatusEnum.Symptomatic:
                    circleOptions.InvokeFillColor(0X33FF4D26);
                    circleOptions.InvokeStrokeColor(0X33FF4D26);
                    NativeMap.AddCircle(circleOptions);
                    break;
                default:
                    break;
            }
/*            circleOptions.InvokeFillColor(0X66FF0000);
            circleOptions.InvokeStrokeColor(0X66FF0000);*/
            

            

            return marker;
        }
    }
}