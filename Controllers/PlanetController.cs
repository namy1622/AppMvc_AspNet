using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{

    // [Route("he-mat-troi")] // --> route controller + route action
    // [Route("he-mat-troi/[action]")] // --> route controller + name Action
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }

        // GET: Planet
        [Route("danh-sach-cac-hanh-tinh.html")]
        public IActionResult Index()
        {
            return View();
        }
        //-------------------------

        // route: action
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name {set; get;} // Action ~ PlanetModel

        public IActionResult Mercury(){

            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Venus(){

            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Earth(){

            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Mars(){

            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [HttpGet("/saomoc.html")] //-> chi truy cap bang pt GET, vowis route = /saomoc.html
        public IActionResult Jupiter(){

            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Saturn(){

            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Uranus(){

            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [Route("hanh-tinh/[action]")] // --> /hanh-tinh/Neptune
        // [Route("[controller]-[action].html")] //--> Planet-Neptune.html
        // [Route("sao/[controller]/[action]")] // --> sao/Planet/Neptune
        public IActionResult Neptune(){

            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        // hoac co the goi theo id
        [Route("hanh-tinh/{id:int}")]
        public IActionResult PlanetInfo(int id){

            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }

    }
}
