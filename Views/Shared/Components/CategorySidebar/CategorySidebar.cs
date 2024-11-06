
using System.Collections.Generic;
using App.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    [ViewComponent]
    public class CategorySidebar : ViewComponent{

        public class CategorySidebarData{

             // chua danh muc can Render
            public List<Category> Categories {set; get;}
            public int level {set; get;}

            public string categoryslug{set;get;}
        }
       
        //

        public IViewComponentResult Invoke(CategorySidebarData data){  // View ma Invoke() goij mac dinh la Default
            return View(data); // truyen data sang cho Default
        }
    }
}

// [ViewComponent]
//     public class CategorySidebar : ViewComponent {

//         public class CategorySidebarData 
//         {
//             public List<Category> Categories { get; set; }
//             public int level { get; set; }

//             public string categoryslug { get; set;}

//         }

//         public IViewComponentResult Invoke(CategorySidebarData data)
//         {
//             return View(data);
//         }

//     }