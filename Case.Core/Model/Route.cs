using System;
using System.Xml.Serialization;

namespace Case.Core.Model
{
    public class Route
    {
        #region Properties

        [XmlElement("VarisYeri")]
        public string ArrivalPlaceName { get; set; }

        [XmlElement("SiraNo")]
        public int Index { get; set; }

        [XmlElement("KalkisTarihSaat")]
        public DateTime DepartureTime { get; set; }

        [XmlElement("VarisTarihSaat")]
        public DateTime ArrivalTime { get; set; }

        [XmlElement("KaraNoktaID")]
        public int PlaceId { get; set; }

        [XmlElement("KaraNoktaAd")]
        public string PlaceName { get; set; }

        #endregion
    }
}
