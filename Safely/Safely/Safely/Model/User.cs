using System;
using System.Collections.Generic;
using System.Text;

namespace Safely.Model
{
    class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

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
    }
}
