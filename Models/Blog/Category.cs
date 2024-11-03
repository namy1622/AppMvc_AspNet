using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Blog
{
    //[Table("Category")]
    public class Category{
        [Key]
        public int Id {set; get;}

       
        // Tieu de category
        [Required(ErrorMessage = "Phai co ten danh muc")]
        [StringLength(100, MinimumLength =3, ErrorMessage = "{0} phai tu {1} den {2} ki tu")]
        public string Title {get; set;}

        //Noi dung, thong tin chi tiet ve Category
        [DataType(DataType.Text)]
        [DisplayName("Noi dung danh muc")]
        public string Description{set; get;}

        //chuoi url
        [Required(ErrorMessage ="Phai tao url")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="{0} dai {1} den {2}")]
        [RegularExpression(@"^[a-z0-9-]*$", ErrorMessage ="Chi dung cac ki tu [a-z,0-9-]")]
        [DisplayName("Url hien thi")]
        public string Slug{set; get;}

        // cac Category con
        public ICollection<Category> CategoryChildren{set; get;}

         // Categoty cha (Fkey)
        [DisplayName("Danh muc cha")]
        public int? ParentCategoryId{get; set;}

        [ForeignKey("ParentCategoryId")]
        [DisplayName("Danh muc cha")]
        public Category ParentCategory{set; get;}
    }
}