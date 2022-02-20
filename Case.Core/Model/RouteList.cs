using System.Collections.Generic;
using System.Xml.Serialization;

namespace Case.Core.Model
{
    [XmlRoot("NewDataSet")]
    public class RouteList
    {
        #region Properties

        [XmlElement("Table1")]
        public List<Route> Routes { get; set; }

        #endregion

        #region Methods

        #region Constructors

        public RouteList()
        {
            Routes = new List<Route>();
        }

        #endregion

        #endregion
    }
}
