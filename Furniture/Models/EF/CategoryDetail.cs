namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryDetail")]
    public partial class CategoryDetail
    {
        public long ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ShortName { get; set; }

        [StringLength(100)]
        public string MetaTitle { get; set; }

        public long? TypeID { get; set; }

        public long? CategoryID { get; set; }

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

        public bool? Status { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Material { get; set; }

        [StringLength(500)]
        public string DesignStyle { get; set; }

        [StringLength(250)]
        public string Size { get; set; }

        [StringLength(500)]
        public string DesignShape { get; set; }

        [StringLength(500)]
        public string SizeDetail { get; set; }

        [StringLength(250)]
        public string Color { get; set; }

        [StringLength(300)]
        public string Pattern1 { get; set; }

        [StringLength(300)]
        public string Pattern2 { get; set; }

        [StringLength(300)]
        public string Pattern3 { get; set; }
    }
}
