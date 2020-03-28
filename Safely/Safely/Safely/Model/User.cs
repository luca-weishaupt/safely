using System;
using System.Collections.Generic;
using System.Text;

namespace Safely.Model
{
    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
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
        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if(this.Email.Equals("") || this.Password.Equals(""))
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
