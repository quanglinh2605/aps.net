//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Greetings.Models.ModelsData
{
    using System;
    using System.Collections.Generic;
    
    public partial class SendMail
    {
        public int ID { get; set; }
        public int IDtemp_user { get; set; }
        public string Sendby { get; set; }
        public string Receiver { get; set; }
        public System.DateTime SendDate { get; set; }
        public string Message { get; set; }
    
        public virtual Temp_User Temp_User { get; set; }
    }
}
