using Case.Core.Abstract;
using Case.Core.Enumerations;
using Case.Core.Model;
using Case.Core.Model.Options;
using Case.Core.Model.Query;
using Case.Core.WebService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Case.Core.Business
{
    public class CaseManager : ICaseManager
    {
        #region Constants



        #endregion

        #region Variables

        private readonly ServiceSoapClient _webServiceClient;
        private readonly ICacheManager _cacheManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly WebServiceOptions _webServiceOptions;

        #endregion

        #region Methods

        #region Constructors

        public CaseManager(IServiceProvider serviceProvider, IOptions<WebServiceOptions> webServiceOptions)
        {
            _webServiceClient = new ServiceSoapClient(ServiceSoapClient.EndpointConfiguration.ServiceSoap);
            _serviceProvider = serviceProvider;
            _cacheManager = serviceProvider.GetRequiredService<ICacheManager>();
            _webServiceOptions = webServiceOptions.Value;
        }

        #endregion

        #region ICaseManager Implementation

        public async Task<List<Place>> GetPlaceListAsync()
        {
            if (_cacheManager.TryGetPlaces(out List<Place> places))
                return places;

            PlaceQuery placeListQuery = _serviceProvider.GetRequiredService<PlaceQuery>();
            XmlIsletResponse response =
                await _webServiceClient.XmlIsletAsync(new XmlIsletRequest(new XmlIsletRequestBody(placeListQuery.QueryElement, _webServiceOptions.AuthenticationElement)));
            XmlSerializer serializer = new XmlSerializer(typeof(PlaceList));
            PlaceList placeList;

            using (TextReader reader = new StringReader(response.Body.XmlIsletResult.OuterXml))
            {
                placeList = (PlaceList)serializer.Deserialize(reader);
            }

            if (placeList != null)
            {
                _cacheManager.SetPlaces(placeList.Places, _webServiceOptions.PlacesRefreshPeriod);
                return placeList.Places;
            }

            return new List<Place>();
        }

        public async Task<List<Trip>> GetTripListAsync(int departurePlaceId, int arrivalPlaceId, DateTime tripDate, ProcessTypes processType, int passengerCount, string clientIp)
        {
            TripQuery tripQuery = _serviceProvider.GetRequiredService<TripQuery>();

            tripQuery.DeparturePlaceId = departurePlaceId;
            tripQuery.ArrivalPlaceId = arrivalPlaceId;
            tripQuery.TripDate = tripDate;
            tripQuery.ProcessType = (int)processType;
            tripQuery.PassengerCount = passengerCount;
            tripQuery.ClientIp = clientIp;

            XmlIsletResponse response =
                await _webServiceClient.XmlIsletAsync(new XmlIsletRequest(new XmlIsletRequestBody(tripQuery.QueryElement, _webServiceOptions.AuthenticationElement)));
            XmlSerializer serializer = new XmlSerializer(typeof(TripList));
            TripList tripList;

            using (TextReader reader = new StringReader(response.Body.XmlIsletResult.OuterXml))
            {
                tripList = (TripList)serializer.Deserialize(reader);
            }

            if (tripList != null)
            {
                tripList.MatchBusAttributes();
                return tripList.Trips;
            }

            return new List<Trip>();
        }

        public async Task<List<Firm>> GetFirmsAsync()
        {
            FirmQuery firmQuery = _serviceProvider.GetRequiredService<FirmQuery>();
            XmlIsletResponse response =
                await _webServiceClient.XmlIsletAsync(new XmlIsletRequest(new XmlIsletRequestBody(firmQuery.QueryElement, _webServiceOptions.AuthenticationElement)));
            XmlSerializer serializer = new XmlSerializer(typeof(FirmList));
            FirmList firmList;

            using (TextReader reader = new StringReader(response.Body.XmlIsletResult.OuterXml))
            {
                firmList = (FirmList)serializer.Deserialize(reader);
            }

            if (firmList != null)
                return firmList.Firms;

            return new List<Firm>();
        }

        public async Task<List<Route>> GetRouteListAsync(int firmId, string lineNumber, int departurePlaceId, int arrivalPlaceId, string tripTrackingNumber, DateTime tripDate)
        {
            RouteQuery routeQuery = _serviceProvider.GetRequiredService<RouteQuery>();

            routeQuery.FirmId = firmId;
            routeQuery.LineNumber = lineNumber;
            routeQuery.DeparturePlaceId = departurePlaceId;
            routeQuery.ArrivalPlaceId = arrivalPlaceId;
            routeQuery.TripTrackingNumber = tripTrackingNumber;
            routeQuery.TripDate = tripDate;

            XmlIsletResponse response =
                await _webServiceClient.XmlIsletAsync(new XmlIsletRequest(new XmlIsletRequestBody(routeQuery.QueryElement, _webServiceOptions.AuthenticationElement)));
            XmlSerializer serializer = new XmlSerializer(typeof(RouteList));
            RouteList routeList;

            using (TextReader reader = new StringReader(response.Body.XmlIsletResult.OuterXml))
            {
                routeList = (RouteList)serializer.Deserialize(reader);
            }

            if (routeList != null)
                return routeList.Routes;

            return new List<Route>();
        }

        #endregion


        #endregion
    }
}
