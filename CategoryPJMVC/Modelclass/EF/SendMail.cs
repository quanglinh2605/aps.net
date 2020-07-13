namespace Modelclass.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SendMail")]
    public partial class SendMail
    {
        public int ID { get; set; }

        public int IDtemp_user { get; set; }

        [Required]
        [StringLength(50)]
        public string Sendby { get; set; }

        [Required]
        [StringLength(50)]
        public string Receiver { get; set; }

        public DateTime SendDate { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public virtual Temp_User Temp_User { get; set; }
    }
}
