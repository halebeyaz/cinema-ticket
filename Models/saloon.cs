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
    
    public partial class saloon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public saloon()
        {
            this.movies1 = new HashSet<movies>();
        }
    
        public int saloon_id { get; set; }
        public string saloon_name { get; set; }
        public Nullable<System.DateTime> saloon_time { get; set; }
        public Nullable<int> m_id { get; set; }
    
        public virtual movies movies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movies> movies1 { get; set; }
    }
}
