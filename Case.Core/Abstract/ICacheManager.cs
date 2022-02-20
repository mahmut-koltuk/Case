using Case.Core.Model;
using System.Collections.Generic;

namespace Case.Core.Abstract
{
    internal interface ICacheManager
    {
        #region Methods

        bool TryGetPlaces(out List<Place> value);
        void SetPlaces(List<Place> value, int absoluteExpiration);
        void RemovePlaces();

        #endregion
    }
}
