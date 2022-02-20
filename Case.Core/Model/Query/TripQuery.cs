using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace Case.Core.Model.Query
{
    public class TripQuery : QueryBase
    {
        #region Constants

        private const string ROOT_ELEMENT_NAME = "Sefer";
        private const string FIRM_ID_ELEMENT_NAME = "FirmaNo";
        private const string DEPARTURE_PLACE_ID_ELEMENT_NAME = "KalkisNoktaID";
        private const string ARRIVAL_PLACE_ID_ELEMENT_NAME = "VarisNoktaID";
        private const string TRIP_DATE_ELEMENT_NAME = "Tarih";
        private const string LIST_SUB_PLACES_ELEMENT_NAME = "AraNoktaGelsin";
        private const string PROCESS_TYPE_ELEMENT_NAME = "IslemTipi";
        private const string PASSENGER_COUNT_ELEMENT_NAME = "YolcuSayisi";
        private const string CLIENT_IP_ELEMENT_NAME = "Ip";

        #endregion

        #region Properties

        public int FirmId { get; set; }
        public int DeparturePlaceId { get; set; }
        public int ArrivalPlaceId { get; set; }
        public DateTime TripDate { get; set; }
        public int ListSubPlaces { get; set; }
        public int ProcessType { get; set; }
        public int PassengerCount { get; set; }
        public string ClientIp { get; set; }
        
        #endregion

        #region Methods

        #region Constructors

        public TripQuery()
        {
            FirmId = 0;
            DeparturePlaceId = default;
            ArrivalPlaceId = default;
            TripDate = DateTime.MinValue;
            ListSubPlaces = 1;
            ProcessType = 0;
            PassengerCount = 1;
            ClientIp = String.Empty;
        }

        #endregion

        #region QueryBase Implementation

        protected override XmlElement GetQueryElement()
        {
            XElement element = new XElement(ROOT_ELEMENT_NAME,
                new XElement(FIRM_ID_ELEMENT_NAME, FirmId),
                new XElement(DEPARTURE_PLACE_ID_ELEMENT_NAME, DeparturePlaceId),
                new XElement(ARRIVAL_PLACE_ID_ELEMENT_NAME, ArrivalPlaceId),
                new XElement(TRIP_DATE_ELEMENT_NAME, TripDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
                new XElement(LIST_SUB_PLACES_ELEMENT_NAME, ListSubPlaces),
                new XElement(PROCESS_TYPE_ELEMENT_NAME, ProcessType),
                new XElement(PASSENGER_COUNT_ELEMENT_NAME, PassengerCount),
                new XElement(CLIENT_IP_ELEMENT_NAME, ClientIp));

            XmlDocument doc = new XmlDocument();

            doc.Load(element.CreateReader());
            return doc.DocumentElement;
        }

        #endregion

        #endregion
    }
}
