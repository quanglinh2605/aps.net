namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        public long ID { get; set; }

        public long? CustomerID { get; set; }

        public long? ProductID { get; set; }

        public bool Status { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? SendDate { get; set; }

        public int? Quantity { get; set; }

        [StringLength(50)]
        public string State { get; set; }
    }
}
