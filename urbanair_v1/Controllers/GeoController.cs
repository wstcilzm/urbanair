using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using urbanair_v1.Models;

namespace urbanair_v1.Controllers
{
    /// <summary>
    /// GetGeoInfos
    /// </summary>
    [RoutePrefix("UrbanAir/Geo")]
    public class GeoController : ApiController
    {

        /// <summary>
        /// Get all cities of UAir
        /// </summary>
        /// <returns>city list</returns>
        [Route("Cities")]
        public IEnumerable<City> GetCityList()
        {
            return null;
        }

        /// <summary>
        /// Get city info by city id
        /// </summary>
        /// <param name="id">city id</param>
        /// <returns>city info</returns>
        [Route("CityInfo/{id}")]
        public City GetCityById(string id)
        {
            return null;
        }

        /// <summary>
        /// Get district info by district id
        /// </summary>
        /// <param name="id">district id</param>
        /// <returns>district info</returns>
        [Route("DistrictInfo/{id}")]
        public District GetDistrictById(string id)
        {
            return null;
        }

        /// <summary>
        /// get province by province id
        /// </summary>
        /// <param name="id">province id</param>
        /// <returns>province info</returns>
        [Route("ProvinceInfo/{id}")]
        public Province GetProvinceById(string id)
        {
            return null;
        }

        /// <summary>
        /// get province list
        /// </summary>
        /// <returns>provinces info</returns>
        [Route("Provinces")]
        public IEnumerable<Province> GetProvinceList()
        {
            return null;
        }

        /// <summary>
        /// get station by station id
        /// </summary>
        /// <param name="id">station id</param>
        /// <returns>station info</returns>
        [Route("StationInfo/{id}")]
        public Station GetStationById(string id)
        {
            return null;
        }

        /// <summary>
        /// get cities's geo info
        /// </summary>
        /// <returns>geo info</returns>
        [Route("GeosInfo")]
        public IEnumerable<CityGeo> GetGeoInfo()
        {
            return null;
        }

        /// <summary>
        /// get nearest station by location
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns>station info</returns>
        [Route("NearestStation")]
        public Station GetNearestStationByLocation(double latitude,double longitude)
        {
            return null;
        }

    }
}