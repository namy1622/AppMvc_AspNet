using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers{
    public class FirstController : Controller{

        private readonly ILogger<FirstController> _logger; // ij de co the su dung Log
        private readonly ProductService _productServie;
        public static string ContentRootPath {set; get;}
        public FirstController(ILogger<FirstController> logger,ProductService productSerVice,IWebHostEnvironment env){
            _logger = logger;

            _productServie = productSerVice;

            ContentRootPath = env.ContentRootPath;
        }

        public string Index(){

           

            return "Day la InDex cua First";
        }

        public void Nothing(){
            _logger.LogInformation("Nothing Action...");
            Response.Headers.Add("hi", "xin chao");
        }
        public object Anything() => DateTime.Now;
        //----------------

        public IActionResult Readme(){
            var content = @"
            Xin chao
            
            Hien tai dang hoc Net MVC 
            
            toi la Nam...";
            return Content(content, "text/plain");
        }
        //doc hinh anh tu Files(co san trong project)
        public IActionResult Loli(){
            // ContentRootPath: la diem bat dau cua du an
            string filePath = Path.Combine(ContentRootPath, "Files", "loli_1.jpg");

            var byte_1 = System.IO.File.ReadAllBytes(filePath);

            return File(byte_1,"image/jpg");
        }

        public IActionResult price(){
            return Json(
                new { // json dang vo danh 
                    productName = "Iphone",
                    price = 10}
            );
            }

         // Redirect --> chuyen huong den trang web, trang trong local,...
        public IActionResult Privacy(){
            var local_url = Url.Action("Privacy","Home"); // chuyen huong den Home/Privacy
            _logger.LogInformation("Chuyen huong den " + local_url);
            return LocalRedirect(local_url);
        }

        public IActionResult Redirect(){
            var url = "https://google.com";
            _logger.LogInformation("Chuyen huong den " + url);
            return Redirect(url);
        }

        //ViewResult | View()
        public IActionResult HelloView(string user){
            if(string.IsNullOrEmpty(user))
                user = "Khach";

            //---------
            // View() -> Razor Engine, doc .cshtml (template)
            // return View("/MyView/xinchao1.cshtml", user);
            //---------
                // xinchao2.cshtml -> /View/First/xinchao2.cshtml
            // return View("xinchao2", user);
            //---------
            // HelloView.csthml -> /View/First/HelloView.cshtml
            //return View((object)user);
            //---------
            return View("xinchao3", user);
        }


        [AcceptVerbs("POST", "GET")]// chi duoc truy cap bang pt POST
        public IActionResult ViewProduct(int? id){
            var product = _productServie.Where(p => p.Id == id).FirstOrDefault();
            if(product == null){
                TempData["StatusMessage"] = "San pham ban tim khong co";
                return Redirect(Url.Action("Index", "Home"));
            }
            //return Content($"San pham ID = {id}");

            // /View/First/ViewProduct.csthml
            // /MyView/First/ViewProduct.cshtml

            // truyen bang  Model
            //return View(product);

            // truyen bang ViewData
            // this.ViewData["product"] = product;
            // return View("ViewProduct2");
        


            // truyen bang ViewBag
            ViewBag.product = product;
            return View("ViewProduct3");

            //truyen data tu trang nay sang trang khac
            // su dung TempData
           // TempData["Thongbao"] = "...."

        }

    }

       
}


//-----------------------------------------------------
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData
            
            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
//--------------------------------------------------------
            // _logger.Log(LogLevel.Warning, "Thong bao");
            // _logger.LogWarning("Thong bao");
            // _logger.LogCritical("Thong bao");
            // _logger.LogDebug("Thong bao");
            // _logger.LogInformation("Thong bao");
            //....
//-----------------------------------------------