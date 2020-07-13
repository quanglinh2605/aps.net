namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FilterPrice")]
    public partial class FilterPrice
    {
        public long ID { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public decimal? StartPrice { get; set; }

        public decimal? EndPrice { get; set; }
    }
}
