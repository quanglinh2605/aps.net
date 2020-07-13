namespace Modelclass.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mailgroup")]
    public partial class Mailgroup
    {
        public int ID { get; set; }

        public int IDMem { get; set; }

        [Required]
        [StringLength(30)]
        public string Mail { get; set; }

        public virtual User User { get; set; }
    }
}
