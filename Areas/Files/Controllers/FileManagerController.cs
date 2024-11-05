using Microsoft.AspNetCore.Mvc;

namespace App.Areas.Files.Controllers
{
    public class FileManagerController : Controller
    {
        [Area("Files")]
      //  [Authorize(Role = RoleName.Administrator + "," + RoleName.Editor)]
        // GET: FileManagerController

        //
        [Route("/file-manager")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
