namespace Modelclass.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int ID { get; set; }

        public int IDMem { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime endDate { get; set; }

        public decimal Price { get; set; }

        public bool status { get; set; }

        public virtual User User { get; set; }
    }
}
