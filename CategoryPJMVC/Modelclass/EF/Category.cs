namespace Modelclass.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Templates = new HashSet<Template>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Occasions { get; set; }

        [DisplayName("Upload File")]
        public string ImageCate { get; set; }

        [NotMapped]
        public HttpPostedFileBase Imagefile { get; set; }

        [StringLength(250)]
        public string Descriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Template> Templates { get; set; }
    }
}
