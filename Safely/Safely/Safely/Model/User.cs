using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Safely.Model
{
    class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public StatusEnum Status { get; set; }
        public enum StatusEnum
        {
            Healthy,
            Symptomatic,
            Diagnosed,
            Recovered
        }

        public User() { }
        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }

        public void updateLocation(float longitude, float latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        public async void getLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    this.Longitude = location.Longitude;
                    this.Latitude = location.Latitude;

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}
