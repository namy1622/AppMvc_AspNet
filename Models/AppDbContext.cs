using App.Models.Blog;
using App.Models.Contacts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Models{

    // App.Models.AppDbContext
    public class AppDbContext : IdentityDbContext<AppUser>{

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // xu ly khi tich hop Identity
            foreach(var entityType in modelBuilder.Model.GetEntityTypes()){
                var tableName = entityType.GetTableName();
                if(tableName.StartsWith("AspNet")){
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            // enity la doi tuong bieu dien category tren CSDL
            modelBuilder.Entity<Category> (entity =>{
                entity.HasIndex(c => c.Slug);

                // entity.HasOne(c => c.ParentCategory)
                //         .WithMany(c => c.CategoryChildren)
                //         .HasForeignKey(c => c.ParentCategoryId)
                //         .OnDelete(DeleteBehavior.Restrict); // Sử dụng Restrict để tránh xóa cascade

            });
        }

        public DbSet<Contact> Contacts{set; get;}

        public DbSet<Category> Categories {set; get;}
    }
}