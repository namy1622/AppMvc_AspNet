using App.Models.Blog;
using App.Models.Contacts;
// using App.Models.Product;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Models
{

    // App.Models.AppDbContext
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // xu ly khi tich hop Identity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            // enity la doi tuong bieu dien category tren CSDL
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(c => c.Slug)
                         .IsUnique();;

                // entity.HasOne(c => c.ParentCategory)
                //         .WithMany(c => c.CategoryChildren)
                //         .HasForeignKey(c => c.ParentCategoryId)
                //         .OnDelete(DeleteBehavior.Restrict); // Sử dụng Restrict để tránh xóa cascade

                modelBuilder.Entity<PostCategory>(entity =>
                {
                    entity.HasKey(c => new { c.PostID, c.CategoryID });
                         
                    // Postcategory la bang phu lien ket bang Category va Post nen nhu tren de thiet lap KEY chung cho PostCategory
                    // neu co PostID = 2, CategoryID = 3
                    // thi PostID = 2, CategoryID= 4 -> true --> thiet lap dduowcj Key
                    //     PostID = 2, CategoryID = 3 -> false

                });

                modelBuilder.Entity<Post>(entity =>
                {
                    entity.HasIndex(p => p.Slug)
                        .IsUnique(); // la duy nhat
                });


            });
        }

        public DbSet<Contact> Contacts { set; get; }

        public DbSet<Category> Categories { set; get; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }

        //  public DbSet<ProductCategoryProduct>  ProductCategoryProducts { get; set; }

        //  public DbSet<ProductPhoto> ProductPhotos { get; set; }
    }
}