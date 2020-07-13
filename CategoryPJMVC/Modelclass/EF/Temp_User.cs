namespace Modelclass.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Temp_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Temp_User()
        {
            SendMails = new HashSet<SendMail>();
        }

        public int ID { get; set; }

        public int UserID { get; set; }

        public int TempID { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string photo { get; set; }

        [Required]
        [StringLength(100)]
        public string music { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SendMail> SendMails { get; set; }

        public virtual Template Template { get; set; }

        public virtual User User { get; set; }
    }
}
