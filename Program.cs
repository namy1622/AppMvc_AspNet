using System.Net;
using App.ExtendMethods;
using App.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

//--- Dang Ki Lop Nhu 1 Dich Vu -------------------------------
builder.Services.AddSingleton<ProductService>();
// cach khac
// builder.Services.AddSingleton<ProductService, ProductService>();
// builder.Services.AddSingleton(typeof(ProductService));
// builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));

builder.Services.AddSingleton<PlanetService>();
//----------------------------------------------------------
builder.Services.Configure<RazorViewEngineOptions>(options =>{
    // /View/Controller/Action.cshtml
    // /MyView/Controller/Action.cshtml

    // {0} -> ten Action
    // {1} -> ten Controller
    // {2} -> ten Area

    // app tu dong build theo duong dan mac dinh la /View/Controller/Action.cshtml
    // neu ko co se chuyen huowng tim theo /MyView/...
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
    // + RazorViewEngine.ViewExtension : la cac duoi nhu .cs .cshtml,...

});
//---------------------------------------------------------

var app = builder.Build();
 
 IWebHostEnvironment envProgram;


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication(); // xac dinh danh tinhs 
app.UseAuthorization(); // xac thuc quyen truy cap 

app.AddStatusCodePage(); // tuy bien response khi cos loi tu 400 - 599

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoint =>{
    // /sayhi
    endpoint.MapGet("/sayhi", async (context) =>{
        await context.Response.WriteAsync($"Hello Asp.Net Mvc - {DateTime.Now}");
    });

    endpoint.MapControllers();

    endpoint.MapControllerRoute(
        name: "first",
        pattern: "{url}/{id:range(2,4)}",
        defaults: new {
            controller = "First",
            action = "ViewProduct"
        },
        constraints: new{  // constraints - doi tuong kieu vo danh, rang buoc cac gia tri
            url = "xemsanpham",  // rang buoc url phai = "xemsanpham" moi duoc truy cap
            // id = new RangeRouteConstraint(2,4) // rang buoc id nam trong khoang 2-4
        }
    );

    //Area
    endpoint.MapAreaControllerRoute(
        name: "product",
        pattern: "/{controller}/{action=Index}/{id?}",
        areaName: "ProductManage"
    );

    // Controller ko co Area
    endpoint.MapControllerRoute(
        name: "default",
        pattern: "/{controller=Home}/{action=Index}/{id?}"
        // defaults: new {
        //     controller = "First",
        //     action = "ViewProduct",
        //     id = 3
        // }
    );

    endpoint.MapRazorPages();
});
#pragma warning restore ASP0014 // Suggest using top level route registrations


app.Run();

//========================================================
/*
    endpoint.MapControllers
    endpoint.MapControllerRoute
    endpoint.MapDefaultControllerRoute
    endpoint.MapAreaControllerRoute

    * Cac Attribute
    [AcceptVerbs] - duoc dung cho cac action 

    [Route]

    [HttpGet]
    [HttpPost]
    [HttpPut]
    [HttpDelete]
    [HttpHead]
    [HttpPatch]
*/
