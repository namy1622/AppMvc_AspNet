## Controller 
<<<<<<< HEAD
- la mot lop ke thua tu lop Controller : Microsoft.AspNetCore.Mvc.Controller
- Action trong controller laf 1 pt public (ko duoc la static)
- Action tra ve bat ki kdl nao, thuong la IActionResult
- Cac dich vu inject vao controller qua ham tao

## View 
- la file .cshtml 
- View cho Action luu tai : /View/ControllerName/ActionName/csthml
- Them thu muc luu tru View:

## Truyen du lieu sang View
- Model
- ViewData
- ViewBag
- TempData

## Areas
- la ten dung de routing
- la cau truc thu muc chua M.V.C
- Thiet lap Area cho controller bang ''' [Area("AreaName")] '''
- Tao cau truc thu muc
```
 dotnet asp-codegenerator area Product
 ```


 //------------

    Cài đặt lệnh dotnet aspnet-codegenerator
```
dotnet tool install -g dotnet-aspnet-codegenerator
```
Packages
```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```
Controller

    Là một lớp kế từ thừa lớp Controller : Microsoft.AspNetCore.Mvc.Controller
    Action trong controller là một phương public (không được static)
    Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
    Các dịch vụ inject vào controller qua hàm tạo
    Tạo controller bằng CLI
```
dotnet aspnet-codegenerator controller -name Product -namespace App.Controllers -outDir Controllers
```
View

    Là file .cshtml
    View cho Action lưu tại: /View/ControllerName/ActionName.cshtml
    Thêm thư mục lưu trữ View:
```
// {0} -> ten Action
// {1} -> ten Controller
// {2} -> ten Area

options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);

options.AreaViewLocationFormats.Add("/MyArea/{1}/View/{1}/{0}.cshtml");
```
Truyền dữ liệu sang View

    Model
    ViewData
    ViewBag
    TempData

Areas

    Là tên dùng để routing
    Là cấu trúc thư mục chứa M.V.C
    Thiết lập Area cho controller bằng [Area("AreaName")]
    Tạo cấu trúc thư mục
```
dotnet aspnet-codegenerator area Product 
```
Route
```
    endpoints.MapControllerRoute
    endpoints.MapAreaControllerRoute
    [AcceptVerbs("POST", "GET")]
    [Route("pattern")]
    [HttpGet] [HttpPost]
```
Url Generation
UrlHelper : Action, ActionLink, RouteUrl, Link
```
Url.Action("PlanetInfo", "Planet", new {id = 1}, Context.Request.Scheme)

Url.RouteUrl("default", new {controller= "First", action="HelloView", id = 1, username =  "XuanThuLab"})
```
/
HtmlTagHelper: <a> <button> <form>
/
Sử dụng thuộc tính:
/
```
asp-area="Area"
asp-action="Action"
asp-controller="Product"
asp-route...="123"
asp-route="default"
```
=======
- la mot lop ke thua tu lop Controller : Microsoft.AspNetCore.Mvc.Controller
>>>>>>> 8f201b5bde0b765474e40473f96c4c326c62d5bd
