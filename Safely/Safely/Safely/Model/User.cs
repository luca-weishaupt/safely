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

    }
}
