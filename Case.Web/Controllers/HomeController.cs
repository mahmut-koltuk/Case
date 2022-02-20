using Case.Core.Abstract;
using Case.Core.Model;
using Case.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Case.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICaseManager _caseManager;

        public HomeController(ILogger<HomeController> logger, ICaseManager caseManager)
        {
            _logger = logger;
            _caseManager = caseManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(TripSearchData data)
        {
            return RedirectToAction("Index", "Trip", data);
        }

        [HttpPost]
        public async Task<JsonResult> GetDeparturePlaceList(string searchBy)
        {
            List<Place> places = await _caseManager.GetPlaceListAsync();
            var placeItems = (from p in places where p.Name.Contains(searchBy, StringComparison.InvariantCultureIgnoreCase) select new { DeparturePlaceId = p.Id, DeparturePlaceName = p.Name });

            return Json(placeItems);
        }

        [HttpPost]
        public async Task<JsonResult> GetArrivalPlaceList(string searchBy)
        {
            List<Place> places = await _caseManager.GetPlaceListAsync();
            var placeItems = (from p in places where p.Name.Contains(searchBy, StringComparison.InvariantCultureIgnoreCase) select new { ArrivalPlaceId = p.Id, ArrivalPlaceName = p.Name });

            return Json(placeItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
