namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Partner")]
    public partial class Partner
    {
        public long ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string images { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
