//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test.Models.ModelsData
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserChat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserChat()
        {
            this.Friends = new HashSet<Friend>();
            this.Friends1 = new HashSet<Friend>();
            this.groupDetails = new HashSet<groupDetail>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string pwd { get; set; }
        public Nullable<bool> active { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Friend> Friends { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Friend> Friends1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<groupDetail> groupDetails { get; set; }
    }
}