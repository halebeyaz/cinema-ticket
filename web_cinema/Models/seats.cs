//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_cinema.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class seats
    {
        public int seat_id { get; set; }
        public string seat_name { get; set; }
        public Nullable<sbyte> isBooked { get; set; }
        public Nullable<int> s_id { get; set; }
    
        public virtual saloon saloon { get; set; }
    }
}
