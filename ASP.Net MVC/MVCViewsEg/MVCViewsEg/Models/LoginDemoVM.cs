using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCViewsEg.Models
{
    public class LoginDemoVM
    {
        [Key]
        [Required]
        public string CustomerID { get; set; }
        [DisplayName("Enter Password")]
        [DataType(DataType.Password)]
        [Required]
        public string CompanyNme { get; set; }
    }
}