//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCLoginRegistrationEg
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDisc
    {
        public int id { get; set; }
        public Nullable<int> movie_id { get; set; }
        public Nullable<double> rent_cost { get; set; }
        public Nullable<bool> is_Available { get; set; }
    
        public virtual tblMovie tblMovie { get; set; }
    }
}
