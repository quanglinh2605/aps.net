//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransportManagerSystem.Models.ModelsData
{
    using System;
    using System.Collections.Generic;
    
    public partial class ownerDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ownerDetail()
        {
            this.TransportDetails = new HashSet<TransportDetail>();
        }
    
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Id_Card { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportDetail> TransportDetails { get; set; }
    }
}
