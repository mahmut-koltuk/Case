using Case.Core.Abstract;
using Case.Core.Business;
using Case.Core.DataAccess;
using Case.Core.Model;
using Case.Core.Model.Options;
using Case.Core.Model.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Case.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region Constants

        private const string WEB_SERVICE_SECTION_NAME = "WebService";

        #endregion

        #region Methods

        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            #region Configurations

            services.Configure<WebServiceOptions>(configuration.GetSection(WEB_SERVICE_SECTION_NAME));

            #endregion

            #region Models

            services.TryAddTransient<WebServiceOptions>();
            services.TryAddTransient<FirmQuery>();
            services.TryAddTransient<PlaceQuery>();
            services.TryAddTransient<RouteQuery>();
            services.TryAddTransient<TripQuery>();
            services.TryAddTransient<BusAttribute>();
            services.TryAddTransient<BusAttributeData>();
            services.TryAddTransient<Firm>();
            services.TryAddTransient<FirmList>();
            services.TryAddTransient<Place>();
            services.TryAddTransient<PlaceList>();
            services.TryAddTransient<Route>();
            services.TryAddTransient<RouteList>();
            services.TryAddTransient<Trip>();
            services.TryAddTransient<TripData>();
            services.TryAddTransient<TripDetailData>();
            services.TryAddTransient<TripList>();
            services.TryAddTransient<TripSearchData>();

            #endregion

            #region Data Contexts

            services.AddDbContext<CaseDataContext>();

            #endregion

            #region Business

            services.TryAddScoped<ICaseManager, CaseManager>();
            services.TryAddSingleton<ICacheManager, CacheManager>();            

            #endregion

            return services;
        }

        #endregion
    }
}
