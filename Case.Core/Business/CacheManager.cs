using Case.Core.Abstract;
using Case.Core.Model;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace Case.Core.Business
{
    internal class CacheManager : ICacheManager
    {
        #region Constants

        private const string PLACES_KEY = "Places";

        #endregion

        #region Variables

        private readonly MemoryCache _cache;

        #endregion

        #region Methods

        #region Constructors

        public CacheManager()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        #endregion

        #region ICacheManager Implementation

        public bool TryGetPlaces(out List<Place> value)
        {
            value = default;

            if (_cache.TryGetValue(PLACES_KEY, out List<Place> result))
            {
                value = result;
                return true;
            }

            return false;
        }

        public void SetPlaces(List<Place> value, int absoluteExpiration)
        {
            MemoryCacheEntryOptions entryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(absoluteExpiration)
            };

            _cache.Set(PLACES_KEY, value, entryOptions);
        }

        public void RemovePlaces()
        {
            _cache.Remove(PLACES_KEY);
        }

        #endregion

        #endregion
    }
}
