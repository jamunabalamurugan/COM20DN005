using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LayoutEg.Models
{
    public partial class SampleUserData
    {
        public int id { get; set; }
        public string username { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Compare("password")]
        [DataType(DataType.Password)]
        public string retype { get; set; }
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public string logintime { get; set; }
    }
}