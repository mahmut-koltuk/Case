using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Case.Core.Model
{
    [XmlRoot("NewDataSet")]
    public class TripList
    {
        #region Properties

        [XmlElement("Table")]
        public List<Trip> Trips { get; set; }

        [XmlElement("OTipOzellik")]
        public List<BusAttribute> BusAttributes { get; set; }

        #endregion

        #region Methods

        #region Constructors

        public TripList()
        {
            Trips = new List<Trip>();
            BusAttributes = new List<BusAttribute>();
        }

        #endregion


        public void MatchBusAttributes()
        {
            if (Trips != null && Trips.Any() && BusAttributes != null && BusAttributes.Any())
            {
                foreach (Trip trip in Trips)
                {
                    for (int i = 0; i < trip.BusAttributeInfo.Length; i++)
                    {
                        if (trip.BusAttributeInfo[i] == '1')
                            trip.BusAttributes.Add(BusAttributes.First(a => a.Index == i));
                    }
                }
            }
        }

        #endregion
    }
}
