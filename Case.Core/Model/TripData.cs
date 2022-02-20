using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Core.Model
{
    public class TripData
    {
        #region Properties

        public int Id { get; set; }
        public int FirmId { get; set; }
        public string FirmName { get; set; }
        public string FirmLogo { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string Route { get; set; }
        public List<BusAttributeData> BusAttributes { get; set; }
        public string Price { get; set; }

        #endregion

        #region Methods

        #region Constructors

        public TripData()
        {
            BusAttributes = new List<BusAttributeData>();
        }

        #endregion

        #endregion
    }
}
