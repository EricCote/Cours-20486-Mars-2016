namespace AWCatalog.Models
{
 
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
 
    [DataContract()]
    [Table("SalesLT.Product")]
    public partial class Product
    {
        [DataMember()]
        public int ProductID { get; set; }

        [DataMember()]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DataMember()]
        [Required]
        [StringLength(25)]
        public string ProductNumber { get; set; }

        [DataMember()]
        [StringLength(15)]
        public string Color { get; set; }

        [DataMember()]
        [Column(TypeName = "money")]
        public decimal StandardCost { get; set; }

        [DataMember()]
        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }

        [DataMember()]
        [StringLength(5)]
        public string Size { get; set; }

        [DataMember()]
        public decimal? Weight { get; set; }

        [DataMember()]
        public int? ProductCategoryID { get; set; }

        [DataMember()]
        public int? ProductModelID { get; set; }

        [DataMember()]
        public DateTime SellStartDate { get; set; }

        [DataMember()]
        public DateTime? SellEndDate { get; set; }

        [DataMember()]
        public DateTime? DiscontinuedDate { get; set; }

        [DataMember()]
        public byte[] ThumbNailPhoto { get; set; }

        [DataMember()]
        [StringLength(50)]
        public string ThumbnailPhotoFileName { get; set; }

        [DataMember()]
        public Guid rowguid { get; set; }

        [DataMember()]
        public DateTime ModifiedDate { get; set; }

    
       // public virtual Category Category { get; set; }
    }
}
