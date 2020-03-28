using System;
using System.Collections.Generic;
using System.Text;

namespace Safely.Model
{
    class Token
    {
        public int Id { get; set; }
        public string Access_token { get; set; }

        public string Error_description { get; set; }

        public Token() { }
    }
}
