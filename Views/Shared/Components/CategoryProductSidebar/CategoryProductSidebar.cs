
using System.Collections.Generic;
using App.Models.Blog;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    [ViewComponent]
    public class CategoryProductSidebar : ViewComponent {

        public class CategorySidebarData 
        {
            public List<Category> Categories { get; set; }
            public int level { get; set; }

            public string categoryslug { get; set;}

        }

        public IViewComponentResult Invoke(CategorySidebarData data)
        {
            return View(data);
        }

    }
}