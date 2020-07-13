namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public long? CategoryID { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifidedDate { get; set; }

        [StringLength(50)]
        public string ModifidedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public bool Status { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        [StringLength(1000)]
        public string Description1 { get; set; }

        [StringLength(1000)]
        public string Description2 { get; set; }

        [StringLength(1000)]
        public string Description3 { get; set; }

        [StringLength(1000)]
        public string Description4 { get; set; }
    }
}
