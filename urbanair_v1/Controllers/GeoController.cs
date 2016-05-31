using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using urbanair_v1.Models;
using urbanair_v1.DAL;
using urbanair_v1.Util;

namespace urbanair_v1.Controllers
{
    /// <summary>
    /// GetGeoInfos
    /// </summary>
    [RoutePrefix("UrbanAir/Geo/{version}")]
    public class GeoController : ApiController
    {

        /// <summary>
        /// Get all cities of UAir
        /// </summary>
        /// <param name="version">api version</param>
        /// <returns>city list</returns>
        [Route("Cities")]
        public string GetCityList(double version)
        {
            return VersionInvoker.Invoke("APIController", "GetCityList", version, null);
        }

        /// <summary>
        /// Get city info by city id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="id">city id</param>
        /// <returns>city info</returns>
        [Route("CityInfo/{id}")]
        public string GetCityById(double version,string id)
        {
            return VersionInvoker.Invoke("APIController", "GetCityById", version, new object[] { id });
        }

        /// <summary>
        /// Get district info by district id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="id">district id</param>
        /// <returns>district info</returns>
        [Route("DistrictInfo/{id}")]
        public string GetDistrictById(double version,string id)
        {
            return VersionInvoker.Invoke("APIController", "GetDistrictById", version, new object[] { id });
        }

        /// <summary>
        /// get province by province id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="id">province id</param>
        /// <returns>province info</returns>
        [Route("ProvinceInfo/{id}")]
        public string GetProvinceById(double version,string id)
        {
            return VersionInvoker.Invoke("APIController", "GetProvinceById", version, new object[] { id });
        }

        /// <summary>
        /// get province list
        /// </summary>
        /// <param name="version">api version</param>
        /// <returns>provinces info</returns>
        [Route("Provinces")]
        public string GetProvinceList(double version)
        {
            return VersionInvoker.Invoke("APIController", "GetProvinceList", version, null);
        }

        /// <summary>
        /// get station by station id
        /// </summary>
        /// <param name="version">api version</param>
        /// <param name="id">station id</param>
        /// <returns>station info</returns>
        [Route("StationInfo/{id}")]
        public string GetStationById(double version,string id)
        {
            return VersionInvoker.Invoke("APIController", "GetStationById", version, new object[] { id });
        }

        /// <summary>
        /// get cities's geo info
        /// </summary>
        /// <returns>geo info</returns>
        [Route("GeosInfo")]
        public string GetGeoInfo()
        {
            return null;
        }

        /// <summary>
        /// get nearest station by location
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns>station info</returns>
        [Route("NearestStation/{latitude}/{longitude}")]
        public string GetNearestStationByLocation(double latitude,double longitude)
        {
            return null;
        }

    }
}