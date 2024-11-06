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
        public  string Title {get; set;}

        //Noi dung, thong tin chi tiet ve Category
        [DataType(DataType.Text)]
        [DisplayName("Noi dung danh muc")]
        public  string Description{set; get;}

        //chuoi url
        [Required(ErrorMessage ="Phai tao url")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="{0} dai {1} den {2}")]
        [RegularExpression(@"^[a-z0-9-]*$", ErrorMessage ="Chi dung cac ki tu [a-z,0-9-]")]
        [DisplayName("Url hien thi")]
        public  string Slug{set; get;}

        // cac Category con
        public  ICollection<Category> CategoryChildren{set; get;}

         // Categoty cha (Fkey)
        [DisplayName("Danh muc cha")]
        public int? ParentCategoryId{get; set;}

        [ForeignKey("ParentCategoryId")]
        [DisplayName("Danh muc cha")]
        public  Category ParentCategory{set; get;}

        internal void ChildCategoryIDs(object value, List<int> ids)
        {
            throw new NotImplementedException();
        }


        // hamf chon theo id( nếu category hiện tại có child thì thêm cả nó vào)
        public void ChildCategoryIDs(ICollection<Category> childcates, List<int> lists){
            if(childcates == null){
                childcates = this.CategoryChildren;
            }

            foreach(Category category in childcates){
                lists.Add(category.Id);
                ChildCategoryIDs(category.CategoryChildren, lists);
            }
        }

        // lay ds danh muc cha
        public List<Category> ListParents(){
            List<Category> li = new List<Category>();
            var parent = this.ParentCategory;
            while(parent != null){
                li.Add(parent);
                parent = parent.ParentCategory;
            }

            li.Reverse();
            return li;
        }
    }
}