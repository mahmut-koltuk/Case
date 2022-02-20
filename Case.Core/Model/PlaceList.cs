using System.Collections.Generic;
using System.Xml.Serialization;

namespace Case.Core.Model
{
    [XmlRoot("KaraNoktalar")]
    public class PlaceList
    {
        #region Properties

        [XmlElement("KaraNokta")]
        public List<Place> Places { get; set; }

        #endregion

        #region Methods

        #region Constructors

        public PlaceList()
        {
            Places = new List<Place>();
        }

        #endregion

        #endregion
    }
}
