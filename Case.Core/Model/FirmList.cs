using System.Collections.Generic;
using System.Xml.Serialization;

namespace Case.Core.Model
{
    [XmlRoot("NewDataSet")]
    public class FirmList
    {
        #region Properties

        [XmlElement("Table")]
        public List<Firm> Firms { get; set; }

        #endregion

        #region Methods

        #region Constructors

        public FirmList()
        {
            Firms = new List<Firm>();
        }

        #endregion

        #endregion
    }
}
