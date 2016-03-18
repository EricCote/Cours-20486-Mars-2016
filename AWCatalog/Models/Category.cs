namespace AWCatalog.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    [Table("SalesLT.ProductCategory")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
            SubCategories = new HashSet<Category>();
        }

        [Key()]
        public int ProductCategoryID { get; set; }

        public int? ParentProductCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        [IgnoreDataMember()]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        [IgnoreDataMember()]
        [JsonIgnore()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> SubCategories { get; set; }

        [IgnoreDataMember()]
        [JsonIgnore()]
        public virtual Category ParentCategory { get; set; }
    }
}
