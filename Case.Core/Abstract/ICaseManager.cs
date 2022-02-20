using Case.Core.Enumerations;
using Case.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Case.Core.Abstract
{
    public interface ICaseManager
    {
        #region Methods

        Task<List<Place>> GetPlaceListAsync();
        Task<List<Trip>> GetTripListAsync(int departurePlaceId, int arrivalPlaceId, DateTime tripDate, ProcessTypes processType, int passengerCount, string clientIp);
        Task<List<Firm>> GetFirmsAsync();
        Task<List<Route>> GetRouteListAsync(int firmId, string lineNumber, int departurePlaceId, int arrivalPlaceId, string tripTrackingNumber, DateTime tripDate);

        #endregion
    }
}
