namespace AWCatalog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AW : DbContext
    {
        public AW()
            : base("name=AW")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.StandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Weight)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithOptional(e => e.ParentCategory)
                .HasForeignKey(e => e.ParentProductCategoryID);
        }
    }
}
