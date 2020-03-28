using System;
using System.Collections.Generic;
using System.Text;

namespace Safely.Model
{

    public enum STATUS
    {
        HEALTHY,
        SYMPTOMATIC,
        DIAGNOSED,
        RECOVERED
    }
    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public STATUS Status { get; set; }

    }
}
