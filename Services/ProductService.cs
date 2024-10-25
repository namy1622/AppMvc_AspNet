using System.Collections.Generic;
using App.Models;

namespace App.Services{
    public class ProductService : List<ProductModel>{

        public ProductService(){
            this.AddRange( new ProductModel[]{
                new ProductModel(){Id = 1, Name = "XiaoMi", Price = 1524},
                new ProductModel(){Id = 2, Name = "iphone", Price = 2342},
                new ProductModel(){Id = 3, Name = "samsung", Price = 23},
                new ProductModel(){Id = 4, Name = "sony", Price = 546}}
            );
        }
    }
}