using System;
using System.Collections.Generic;
using System.Text;

namespace Safely.Model
{
    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        enum Status {
            Healthy,
            Symptomatic,
            Diagnosed,
            Recovered
        }

        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if(this.Username.Equals("") || this.Password.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
