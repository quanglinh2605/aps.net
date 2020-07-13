namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ShortName { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public long? TypeID { get; set; }

        public long? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string SeoTittle { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifidedDate { get; set; }

        [StringLength(50)]
        public string ModifidedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public bool? Status { get; set; }

        public bool? ShowOnHome { get; set; }

        [StringLength(250)]
        public string Material { get; set; }

        [StringLength(250)]
        public string DesignStyle { get; set; }

        [StringLength(250)]
        public string Size { get; set; }

        [StringLength(100)]
        public string DesignShape { get; set; }

        [StringLength(250)]
        public string SizeDetail { get; set; }

        [StringLength(250)]
        public string Color { get; set; }

        [StringLength(250)]
        public string Pattern1 { get; set; }

        [StringLength(250)]
        public string Pattern2 { get; set; }

        [StringLength(250)]
        public string Pattern3 { get; set; }
    }
}
