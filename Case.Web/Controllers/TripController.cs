using Case.Core.Abstract;
using Case.Core.Enumerations;
using Case.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case.Web.Controllers
{
    public class TripController : Controller
    {
        private readonly ILogger<TripController> _logger;
        private readonly ICaseManager _caseManager;
        private readonly IServiceProvider _serviceProvider;

        public TripController(ILogger<TripController> logger, ICaseManager caseManager, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _caseManager = caseManager;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index(TripSearchData data)
        {
            string clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (String.IsNullOrWhiteSpace(clientIp) || clientIp.Equals("::1"))
                clientIp = "127.0.0.1";

            List<Trip> trips = await _caseManager.GetTripListAsync(data.DeparturePlaceId, data.ArrivalPlaceId, data.TripDate, ProcessTypes.Reservation, 1, clientIp);
            List<Firm> firms = await _caseManager.GetFirmsAsync();
            List<TripData> tripDataList = new List<TripData>();

            foreach (Trip trip in trips)
            {
                TripData tripData = _serviceProvider.GetRequiredService<TripData>();

                tripData.Id = trip.Id;
                tripData.FirmId = trip.FirmId;
                tripData.FirmLogo = firms.FirstOrDefault(f => f.Id == trip.FirmId)?.Logo; //"https://eticket.ipektr.com/wsbos3/LogoVer.Aspx?fnum=37";
                tripData.FirmName = trip.FirmName; //"İnci Turizm";
                tripData.Time = trip.TripTime.ToShortTimeString();
                tripData.Duration = "5 sa";
                tripData.Route = trip.Route; //"Kayseri -&gt;Ankara (Aşti) ";

                foreach (BusAttribute busAttribute in trip.BusAttributes)
                {
                    tripData.BusAttributes.Add(new BusAttributeData { Description = busAttribute.Description, Icon = busAttribute.Icon });
                }

                tripData.Price = $"{trip.TicketPrice} ₺";
                tripDataList.Add(tripData);
            }

            return View(tripDataList);
        }

        [HttpPost]
        public IActionResult Details(int tripDataId)
        {
            TripDetailData tripDetailData = new TripDetailData();

            tripDetailData.FirmLogo = "https://eticket.ipektr.com/wsbos3/LogoVer.Aspx?fnum=37";
            tripDetailData.FirmName = "İnci Turizm";
            tripDetailData.Route = "Kayseri -&gt;Ankara (Aşti) ";

            return PartialView("_DetailsPartial", tripDetailData);
        }
    }
}
