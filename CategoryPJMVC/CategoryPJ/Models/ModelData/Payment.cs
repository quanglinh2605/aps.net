//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CategoryPJ.Models.ModelData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int ID { get; set; }
        public int IDMem { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime endDate { get; set; }
        public decimal Price { get; set; }
        public bool status { get; set; }
    
        public virtual User User { get; set; }
    }
}