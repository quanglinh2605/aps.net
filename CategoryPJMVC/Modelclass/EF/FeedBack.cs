namespace Modelclass.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? IDMem { get; set; }

        [StringLength(30)]
        public string Phonenumber { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Text { get; set; }

        public virtual User User { get; set; }
    }
}
