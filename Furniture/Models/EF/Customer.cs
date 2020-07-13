namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public long ID { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public long? ProvinceID { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}
