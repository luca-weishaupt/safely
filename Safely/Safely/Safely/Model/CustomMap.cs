using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CustomRenderer
{
    
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
        
    }
}
