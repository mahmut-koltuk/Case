using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace Case.Core.Model.Query
{
    public class RouteQuery : QueryBase
    {
        #region Constants

        private const string ROOT_ELEMENT_NAME = "Hat";
        private const string FIRM_ID_ELEMENT_NAME = "FirmaNo";
        private const string LINE_NUMBER_ELEMENT_NAME = "HatNo";
        private const string DEPARTURE_PLACE_ID_ELEMENT_NAME = "KalkisNoktaID";
        private const string ARRIVAL_PLACE_ID_ELEMENT_NAME = "VarisNoktaID";
        private const string PROCESS_TYPE_ELEMENT_NAME = "BilgiIslemAdi";
        private const string TRIP_TRACKING_NUMBER_ELEMENT_NAME = "SeferTakipNo";
        private const string TRIP_DATE_ELEMENT_NAME = "Tarih";
        private const string PROCESS_TYPE_DEFAULT_VALUE = "GuzergahVerSaatli";

        #endregion

        #region Properties

        public int FirmId { get; set; }
        public string LineNumber { get; set; }
        public int DeparturePlaceId { get; set; }
        public int ArrivalPlaceId { get; set; }
        public string ProcessType { get; set; }
        public string TripTrackingNumber { get; set; }
        public DateTime TripDate { get; set; }

        #endregion

        #region Methods

        #region Constructors

        public RouteQuery()
        {
            FirmId = default;
            LineNumber = default;
            DeparturePlaceId = default;
            ArrivalPlaceId = default;
            ProcessType = PROCESS_TYPE_DEFAULT_VALUE;
            TripTrackingNumber = default;
            TripDate = DateTime.Now;
        }

        #endregion

        #region QueryBase Implementation

        protected override XmlElement GetQueryElement()
        {
            XElement element = new XElement(ROOT_ELEMENT_NAME,
                new XElement(FIRM_ID_ELEMENT_NAME, FirmId),
                new XElement(LINE_NUMBER_ELEMENT_NAME, LineNumber),
                new XElement(DEPARTURE_PLACE_ID_ELEMENT_NAME, DeparturePlaceId),
                new XElement(ARRIVAL_PLACE_ID_ELEMENT_NAME, ArrivalPlaceId),
                new XElement(PROCESS_TYPE_ELEMENT_NAME, ProcessType),
                new XElement(TRIP_TRACKING_NUMBER_ELEMENT_NAME, TripTrackingNumber),
                new XElement(TRIP_DATE_ELEMENT_NAME, TripDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));

            XmlDocument doc = new XmlDocument();

            doc.Load(element.CreateReader());
            return doc.DocumentElement;
        }

        #endregion

        #endregion
    }
}
