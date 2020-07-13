namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProduceDetail")]
    public partial class ProduceDetail
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public bool Status { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public long? ProduceID { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(1000)]
        public string Description2 { get; set; }

        [StringLength(1000)]
        public string Description1 { get; set; }

        [StringLength(1000)]
        public string Description3 { get; set; }

        [StringLength(1000)]
        public string Description4 { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? ModifidedDate { get; set; }

        [StringLength(100)]
        public string ModifidedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }
    }
}
