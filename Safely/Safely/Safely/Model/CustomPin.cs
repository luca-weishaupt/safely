using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using static Safely.Model.User;

namespace CustomRenderer
{
    public class CustomPin : Pin
    {
        public StatusEnum Status { get; set; }
    }
}
