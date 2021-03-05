using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlHelpersEx.Models
{
    public class Register
    {
        public string name { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public string gender { get; set; }
        public string interest { get; set; }
    }
    public enum cities
    {
        Chennai,Mumbai,Pune,Delhi
    }

}